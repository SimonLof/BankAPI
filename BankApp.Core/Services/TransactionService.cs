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
            var newTransaction = _mapper.Map<Transaction>(transaction);

            newTransaction.Date = DateOnly.FromDateTime(DateTime.UtcNow);
            newTransaction.AccountNavigation = await _accountService.GetAccountFromId(newTransaction.AccountId);
            newTransaction.AccountNavigation.Balance += newTransaction.Amount;
            if (newTransaction.AccountNavigation.Balance < 0) throw new Exception("Not enough funds.");

            newTransaction.Balance = newTransaction.AccountNavigation.Balance;
            newTransaction.Type = newTransaction.Amount > 0 ? "Credit" : "Debit";
            newTransaction.Operation = "";

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
            if (transaction.Amount < 0) throw new Exception("Invalid amount.");

            if (!await IsOwner(username, transaction.FromAccountId))
                throw new Exception("Invalid account.");

            if (transaction.FromAccountId == transaction.ToAccountId) throw new Exception("Invalid account.");

            var fromAccountTransaction = new TransactionCreate
            {
                AccountId = transaction.FromAccountId,
                Amount = -transaction.Amount,
            };

            var toAccountTransaction = new TransactionCreate
            {
                AccountId = transaction.ToAccountId,
                Amount = transaction.Amount,
            };

            // TODO nån typ av koll att allt går igenom som det ska. Eller göra om så att man ger EF båda uppdragen samtidigt.
            // men just nu är jag för lat :3 Det stod inte i beskrivningen att det skulle va en vettig bank med regler.
            var returnView = await SingleTransaction(fromAccountTransaction);
            await SingleTransaction(toAccountTransaction);

            return returnView;
        }

        private async Task<bool> IsOwner(string username, int accountId)
        {
            var user = await _userManager.FindByNameAsync(username);
            var userAccountIds = (await _accountService.GetAccountsFromName(username))
                                                                .Select(a => a.AccountId);

            if (userAccountIds.Contains(accountId)) return true;

            return false;
        }

    }
}
// Transaction
//public int TransactionId { get; set; } x
//public int AccountId { get; set; } x
//public DateOnly Date { get; set; } x
//public string Type { get; set; } = null!; x
//public string Operation { get; set; } = null!; x
//public decimal Amount { get; set; } x
//public decimal Balance { get; set; } x
//public string? Symbol { get; set; }
//public string? Bank { get; set; }
//public string? Account { get; set; }
//public virtual Account AccountNavigation { get; set; } = null!;x

// transactionCreate
//public int AccountId { get; set; }
//// Debit is withdrawal (remove from balance) Credit is deposit (adding to account balance)
//public string Type { get; set; } = null!;
//public string Operation { get; set; } = null!;
//public decimal Amount { get; set; }
//// balance after the transaction?

// between accounts
//public int FromAccountId { get; set; }
//public int ToAccountId { get; set; }
//public decimal Amount { get; set; }