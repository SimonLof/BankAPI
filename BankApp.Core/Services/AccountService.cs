using AutoMapper;
using BankApp.Core.Interfaces;
using BankApp.Data.Interfaces;
using BankApp.Domain.DTO;
using BankApp.Domain.Entities;

namespace BankApp.Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly IAccountRepo _accountRepo;

        public AccountService(IAccountRepo accountRepo, IMapper mapper)
        {
            _accountRepo = accountRepo;
            _mapper = mapper;
        }

        public async Task CreateAccount(AccountCreateModel accountCreateModel)
        {
            var newAccount = _mapper.Map<Account>(accountCreateModel);
            newAccount.Created = DateOnly.FromDateTime(DateTime.UtcNow);

            var accountWithId = await _accountRepo.CreateAccount(newAccount);

            var newAccountDisposition = _mapper.Map<Disposition>(accountCreateModel);
            newAccountDisposition.AccountId = accountWithId.AccountId;
            await _accountRepo.CreateDisposition(newAccountDisposition);
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