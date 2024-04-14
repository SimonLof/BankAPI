using AutoMapper;
using BankApp.Core.Interfaces;
using BankApp.Data.Identity;
using BankApp.Data.Interfaces;
using BankApp.Domain.DTO;
using BankApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace BankApp.Core.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepo _transactionRepo;
        private readonly IAccountService _accountService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public TransactionService(ITransactionRepo transactionRepo,
                                  IMapper mapper,
                                  IAccountService accountService,
                                  UserManager<ApplicationUser> userManager)
        {
            _transactionRepo = transactionRepo;
            _mapper = mapper;
            _accountService = accountService;
            _userManager = userManager;
        }

        public async Task<TransactionView> SingleTransaction(TransactionCreate transaction)
        {
            Transaction newTransaction = await MakeNewTransaction(transaction);

            var createdTransaction = await _transactionRepo.CreateTransaction(newTransaction);

            return _mapper.Map<TransactionView>(createdTransaction);
        }


        public async Task<TransactionView> CustomerSingleTransaction(TransactionCreate transaction, string username)
        {
            if (!await IsOwner(username, transaction.AccountId))
                throw new Exception("Invalid account.");

            return await SingleTransaction(transaction);
        }

        public async Task<TransactionView> TransferTransaction(TransactionBetweenAccountsCreate transaction, string username)
        {
            string validationResult = await ValidateTransaction(transaction, username);
            if (validationResult != "") throw new Exception(validationResult);

            var fromAccountTransaction =
                TransactionCreate.TransactionCreateFactory(transaction.FromAccountId, -transaction.Amount);

            var toAccountTransaction =
                TransactionCreate.TransactionCreateFactory(transaction.ToAccountId, transaction.Amount);

            var returnView = await SingleTransaction(fromAccountTransaction);
            await SingleTransaction(toAccountTransaction);

            return returnView;
        }
        private async Task<Transaction> MakeNewTransaction(TransactionCreate transaction)
        {
            var newTransaction = _mapper.Map<Transaction>(transaction);

            newTransaction.Date = DateOnly.FromDateTime(DateTime.UtcNow);
            // Borde jag använda den andra servicen här, eller låta repon lägga till usern?
            newTransaction.AccountNavigation = await _accountService.GetAccountFromId(newTransaction.AccountId);
            newTransaction.AccountNavigation.Balance += newTransaction.Amount;
            if (newTransaction.AccountNavigation.Balance < 0) throw new Exception("Not enough funds.");

            newTransaction.Balance = newTransaction.AccountNavigation.Balance;
            newTransaction.Type = newTransaction.Amount > 0 ? "Credit" : "Debit";
            newTransaction.Operation = "";
            return newTransaction;
        }

        private async Task<string> ValidateTransaction(TransactionBetweenAccountsCreate transaction, string username)
        {
            // kanske göra en enum här istället.
            string validationResult = "";

            if (transaction.Amount < 0) validationResult = "Can't transfer negative values.";
            else if (!(await IsOwner(username, transaction.FromAccountId))) validationResult = "You are not the owner of this account.";
            else if (!(await HasIdGotAccount(transaction.ToAccountId))) validationResult = "Account not found.";
            else if (transaction.FromAccountId == transaction.ToAccountId) validationResult = "Can't transfer to same account.";

            return validationResult;
        }

        private async Task<bool> IsOwner(string username, int accountId)
        {
            var user = await _userManager.FindByNameAsync(username);
            var userAccountIds = (await _accountService.GetAccountsFromName(username))
                                                                .Select(a => a.AccountId);

            if (userAccountIds.Contains(accountId)) return true;

            return false;
        }

        private async Task<bool> HasIdGotAccount(int accountId)
        {
            var result = (await _accountService.GetAccountFromId(accountId) is not null);
            return result;
        }
    }
}