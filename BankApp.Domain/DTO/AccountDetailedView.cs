namespace BankApp.Domain.DTO
{
    public class AccountDetailedView
    {
        public int AccountId { get; set; }
        public decimal Balance { get; set; }
        public string AccountType { get; set; }
        public ICollection<TransactionView> Transactions { get; set; }
    }
}
