using BankApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace BankApp.Data.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public virtual Customer? Customer { get; set; }
    }
}
