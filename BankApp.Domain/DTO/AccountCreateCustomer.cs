namespace BankApp.Domain.DTO
{
    public class AccountCreateCustomer
    {
        // frequency of payments for loans.
        public string Frequency { get; set; } = null!;
        // s for savings account, t for transaction account.
        public char AccountType { get; set; }
    }
}