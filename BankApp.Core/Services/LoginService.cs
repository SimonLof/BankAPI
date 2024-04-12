using BankApp.Core.Interfaces;
using BankApp.Data.Identity;
using BankApp.Domain.DTO;
using Microsoft.AspNetCore.Identity;

namespace BankApp.Core.Services
{
    public class LoginService : ILoginService
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public LoginService(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
        }

        public async Task Login(UserLoginModel loginDTO)
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
