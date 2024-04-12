using BankApp.Core.Interfaces;
using BankApp.Domain.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrator")]
    public class AdminController : ControllerBase
    {
        private readonly ITestService _testService;
        private readonly IUserService _userService;

        public AdminController(ITestService testService, IUserService userService)
        {
            _testService = testService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Testing()
        {
            return Ok(await _testService.GetFirstAccount());
        }

        [AllowAnonymous]
        [HttpGet("/whoami")]
        public async Task<IActionResult> WhoAmI()
        {
            // TODO gör en loop, och skapa ett anonymt objekt som innehåller alla claims och username. Kanske userID också.
            return Ok(User.Claims.FirstOrDefault());
        }

        [HttpGet("/getallusers")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                return Ok(await _testService.GetAllUsers());
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost("/newcustomer")]
        public async Task<IActionResult> CreateCustomer(UserCreateModel newUser)
        {
            //try
            //{
            if (newUser == null) return BadRequest();

            var result = await _userService.CreateCustomer(newUser);

            if (result.Succeeded)
                return Ok();
            //}
            //catch (Exception e)
            //{
            //    return BadRequest(e);
            //}

            return BadRequest("what");
        }
        [AllowAnonymous]
        [HttpPost("/createadmin")]
        public async Task<IActionResult> CreateAdmin(UserCreateModel newAdmin)
        {
            var res = await _userService.CreateAdmin(newAdmin);
            if (res.Succeeded)
                return Ok(res);

            return BadRequest();
        }
    }
}
