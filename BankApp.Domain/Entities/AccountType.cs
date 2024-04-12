namespace BankApp.Domain.Entities;

public enum AccountTypeEnum
{
    StandardTransactionAccount = 1,
    SavingsAccount = 2,
}

public partial class AccountType
{
    public int AccountTypeId { get; set; }
    public string TypeName { get; set; } = null!;
    public string? Description { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}
