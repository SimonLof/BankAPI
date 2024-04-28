namespace BankApp.Domain.DTO
{
    public class TransactionCreateDTO
    {
        public int AccountId { get; set; }
        // Debit is withdrawal (remove from balance) Credit is deposit (adding to account balance)
        public decimal Amount { get; set; }

        public static TransactionCreateDTO TransactionCreateFactory(int accountId, decimal amount)
        {
            return new TransactionCreateDTO { AccountId = accountId, Amount = amount };
        }
    }
}
