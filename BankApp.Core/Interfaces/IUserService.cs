using BankApp.Domain.DTO;
using Microsoft.AspNetCore.Identity;

namespace BankApp.Core.Interfaces
{
    public interface IUserService
    {
        Task<IdentityResult> CreateAdmin(UserCreateModel user);
        Task<IdentityResult> CreateCustomer(UserCreateModel user);
    }
}
