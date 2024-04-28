namespace BankApp.Domain.DTO
{
    public class TransactionBetweenAccountsCreateDTO
    {
        public int FromAccountId { get; set; }
        public int ToAccountId { get; set; }
        public decimal Amount { get; set; }
    }
}
