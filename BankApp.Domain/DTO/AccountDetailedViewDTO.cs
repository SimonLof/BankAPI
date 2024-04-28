namespace BankApp.Domain.DTO
{
    public class AccountDetailedViewDTO
    {
        public int AccountId { get; set; }
        public decimal Balance { get; set; }
        public string AccountType { get; set; }
        public ICollection<TransactionViewDTO> Transactions { get; set; }
    }
}
