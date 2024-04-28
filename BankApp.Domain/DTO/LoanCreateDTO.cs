namespace BankApp.Domain.DTO
{
    public class LoanCreateDTO
    {
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
        public int Duration { get; set; }
    }
}
