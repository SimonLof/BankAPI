using AutoMapper;
using BankApp.Core.Interfaces;
using BankApp.Data.Identity;
using BankApp.Data.Interfaces;
using BankApp.Domain.DTO;
using BankApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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
            if (username.IsNullOrEmpty()) throw new Exception("Invalid username.");

            var user = await _userManager.Users
                   .Include(a => a.Customer)
                   .FirstOrDefaultAsync(a => a.NormalizedUserName == username.ToUpper())
                   ?? throw new Exception("User not found.");

            var newCustomerCreatedAccount = new AccountCreate
            {
                CustomerId = user.Customer.CustomerId,
                AccountTypesId =
                    accountCreateModel.AccountType is 't' or 'T' ?
                        AccountTypeEnum.StandardTransactionAccount :
                        accountCreateModel.AccountType is 's' or 'S' ?
                            AccountTypeEnum.SavingsAccount :
                                throw new Exception("Invalid account type"),
                Balance = 0,
                DispositionType = "DISPONENT",
                Frequency = accountCreateModel.Frequency,
            };
            await CreateAccount(newCustomerCreatedAccount);
        }

        public async Task<List<AccountSimpleView>> GetAccounts(string username)
        {
            var user = await _userManager.Users
                .Include(a => a.Customer)
                .ThenInclude(c => c.Dispositions)
                .ThenInclude(d => d.Account)
                .FirstOrDefaultAsync(a => a.UserName == username);
            var customerAccounts = user.Customer.Dispositions.Select(d => d.Account).ToList();
            List<AccountSimpleView> returnAccounts = [];
            foreach (var account in customerAccounts)
                returnAccounts.Add(_mapper.Map<AccountSimpleView>(account));

            return returnAccounts;
        }
    }
}

//// saker för att veta wtf is going on.
// required account stuff
//public int AccountId { get; set; }
//public string Frequency { get; set; } = null!;
//public DateOnly Created { get; set; }
//public decimal Balance { get; set; }

// createmodel stuff
// Frequency can be monthly or weekly.
//public string Frequency { get; set; } = null!;
//public decimal Balance { get; set; }
//public int CustomerId { get; set; }
//// OWNER if main account. DISPONENT if extra added account.
//public string DispositionType { get; set; } = null!;
//public int? AccountTypesId { get; set; }

// hela disposition
//public int DispositionId { get; set; }
//public int CustomerId { get; set; }
//public int AccountId { get; set; }
//public string Type { get; set; } = null!;
//public virtual Account Account { get; set; } = null!;
//public virtual ICollection<Card> Cards { get; set; } = new List<Card>();
//public virtual Customer Customer { get; set; } = null!;