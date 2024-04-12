using BankApp.Core.Interfaces;
using BankApp.Data.Identity;
using BankApp.Domain.DTO;
using Microsoft.AspNetCore.Identity;

namespace BankApp.Core.Services
{
    public class LoginService : ILoginService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public LoginService(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task Login(UserLogin loginDTO)
        {
            var result = await _signInManager
                .PasswordSignInAsync(loginDTO.UserName, loginDTO.Password, false, false);

            if (result.Succeeded) return;

            throw new Exception("Login Failed.");
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
