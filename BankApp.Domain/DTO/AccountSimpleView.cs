namespace BankApp.Domain.DTO
{
    public class AccountSimpleView
    {
        public int AccountId { get; set; }
        public decimal Balance { get; set; }
        public string AccountType { get; set; }
    }
}
