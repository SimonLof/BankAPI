namespace BankApp.Domain.DTO
{
    public class AccountCreateByCustomer
    {
        // frequency of payments for loans. (weekly/monthly)
        public string Frequency { get; set; } = null!;
        // s for savings account, t for transaction account.
        public string AccountType { get; set; }
    }
}