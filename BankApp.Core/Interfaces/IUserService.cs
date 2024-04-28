using BankApp.Domain.DTO;
using Microsoft.AspNetCore.Identity;

namespace BankApp.Core.Interfaces
{
    public interface IUserService
    {
        Task<IdentityResult> CreateAdmin(UserCreateDTO user);
        Task<IdentityResult> CreateCustomer(UserCreateDTO user);
    }
}
