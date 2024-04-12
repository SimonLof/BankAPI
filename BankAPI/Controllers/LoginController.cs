using BankApp.Core.Interfaces;
using BankApp.Domain.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService userService)
        {
            _loginService = userService;
        }

        [HttpPost("/login")]
        public async Task<IActionResult> Login(UserLoginModel userLogin)
        {
            if (userLogin == null)
                return BadRequest();

            await _loginService.Login(userLogin);

            return Ok("You are logged in!");
        }

        [HttpGet("/logout")]
        public async Task<IActionResult> Logout()
        {
            try
            {
                if (User is not null)
                {
                    await _loginService.Logout();
                    return Ok();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return BadRequest();
        }
    }
}
