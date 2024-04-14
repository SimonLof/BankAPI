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

        [HttpPost]
        public async Task<IActionResult> Login(UserLogin userLogin)
        {
            try
            {
                if (userLogin is null)
                    return BadRequest(new { Error = "Login object required." });

                if (await _loginService.Login(userLogin))
                    return Ok("You are logged in!");

                return BadRequest(new { Error = "Login failed." });
            }
            catch (Exception e)
            {
                return BadRequest(new { Error = e.Message });
            }
        }

        [HttpGet("/api/logout")]
        public async Task<IActionResult> Logout()
        {
            try
            {
                if (User is not null)
                {
                    await _loginService.Logout();
                    return Ok();
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(new { Error = e.Message });
            }
        }
    }
}
