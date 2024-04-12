using BankApp.Domain.DTO;
using Microsoft.AspNetCore.Identity;

namespace BankApp.Core.Interfaces
{
    public interface IUserService
    {
        Task<IdentityResult> CreateAdmin(UserCreate user);
        Task<IdentityResult> CreateCustomer(UserCreate user);
    }
}
