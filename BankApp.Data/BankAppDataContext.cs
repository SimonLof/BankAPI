using BankApp.Data.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BankApp.Domain.Entities;

public partial class BankAppDataContext : IdentityDbContext<ApplicationUser>
{
    public BankAppDataContext(DbContextOptions<BankAppDataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }
    public virtual DbSet<AccountType> AccountTypes { get; set; }
    public virtual DbSet<Card> Cards { get; set; }
    public virtual DbSet<Customer> Customers { get; set; }
    public virtual DbSet<Disposition> Dispositions { get; set; }
    public virtual DbSet<Loan> Loans { get; set; }
    public virtual DbSet<Transaction> Transactions { get; set; }
}
