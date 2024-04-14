namespace BankApp.Domain.DTO
{
    public class TransactionCreate
    {
        public int AccountId { get; set; }
        // Debit is withdrawal (remove from balance) Credit is deposit (adding to account balance)
        public decimal Amount { get; set; }

        public static TransactionCreate TransactionCreateFactory(int accountId, decimal amount)
        {
            return new TransactionCreate { AccountId = accountId, Amount = amount };
        }
    }
}
