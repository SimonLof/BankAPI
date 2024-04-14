using AutoMapper;
using BankApp.Core.Interfaces;
using BankApp.Data.Identity;
using BankApp.Data.Interfaces;
using BankApp.Domain.DTO;
using BankApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly IAccountRepo _accountRepo;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountService(IAccountRepo accountRepo, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _accountRepo = accountRepo;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task CreateAccount(AccountCreate accountCreateModel)
        {
            var newAccount = _mapper.Map<Account>(accountCreateModel);
            newAccount.Created = DateOnly.FromDateTime(DateTime.UtcNow);

            var accountWithId = await _accountRepo.CreateAccount(newAccount);

            var newAccountDisposition = _mapper.Map<Disposition>(accountCreateModel);
            newAccountDisposition.AccountId = accountWithId.AccountId;

            await _accountRepo.CreateDisposition(newAccountDisposition);
        }

        public async Task UserCreateAccount(AccountCreateCustomer accountCreateModel, string username)
        {
            var user = await GetUserFromUsername(username, false);
            var newCustomerCreatedAccount =
                AccountCreate.AccountCreateFactory(accountCreateModel, user.Customer.CustomerId);
            await CreateAccount(newCustomerCreatedAccount);
        }



        public async Task<List<AccountSimpleView>> GetAccountsFromName(string username)
        {
            var user = await GetUserFromUsername(username, true);

            if (user.Customer is null) throw new Exception("User is not a customer.");

            var customerAccounts = user.Customer.Dispositions.Select(d => d.Account).ToList();

            List<AccountSimpleView> returnAccounts = [];

            foreach (var account in customerAccounts)
                returnAccounts.Add(_mapper.Map<AccountSimpleView>(account));

            return returnAccounts;
        }

        public async Task<Account> GetAccountFromId(int id)
        {
            return await _accountRepo.GetAccount(id);
        }

        public async Task<AccountDetailedView> CustomerGetAccountWithTransactions(int id, string username)
        {
            var user = await GetUserFromUsername(username, true);
            var userAccountIds = user.Customer.Dispositions.Select(d => d.Account)
                                                            .Select(a => a.AccountId).ToList();

            if (!userAccountIds.Contains(id)) throw new Exception("Invalid account.");

            var account = await _accountRepo.GetAccountWithTransactions(id);
            return _mapper.Map<AccountDetailedView>(account);
        }

        private async Task<ApplicationUser?> GetUserFromUsername(string username, bool bigInclude)
        {
            ApplicationUser user;
            if (bigInclude)
            {
                user = await _userManager.Users
                                        .Include(a => a.Customer)
                                        .ThenInclude(c => c.Dispositions)
                                        .ThenInclude(d => d.Account)
                                        .FirstOrDefaultAsync(a => a.NormalizedUserName == username.ToUpper())
                                        ?? throw new Exception("User not found");
            }
            else
            {
                user = await _userManager.Users
                   .Include(a => a.Customer)
                   .FirstOrDefaultAsync(a => a.NormalizedUserName == username.ToUpper())
                   ?? throw new Exception("User not found.");
            }

            return user;
        }
    }
}