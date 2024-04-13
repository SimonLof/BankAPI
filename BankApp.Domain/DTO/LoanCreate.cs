namespace BankApp.Domain.DTO
{
    public class LoanCreate
    {
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
        public int Duration { get; set; }
    }
}
