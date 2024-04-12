namespace BankApp.Domain.DTO
{
    public class AccountCreateModel
    {
        public string Frequency { get; set; } = null!;
        public decimal Balance { get; set; }
        public int CustomerId { get; set; }
        // OWNER if main account. DISPONENT if extra added account.
        public string DispositionType { get; set; } = null!;
        public int? AccountTypesId { get; set; }
    }
}

//public virtual Account Account { get; set; } = null!;

//public virtual ICollection<Card> Cards { get; set; } = new List<Card>();

//public virtual Customer Customer { get; set; } = null!;
