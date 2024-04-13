namespace BankApp.Domain.DTO
{
    public class TransactionBetweenAccountsCreate
    {
        public int FromAccountId { get; set; }
        public int ToAccountId { get; set; }
        public decimal Amount { get; set; }
    }
}
