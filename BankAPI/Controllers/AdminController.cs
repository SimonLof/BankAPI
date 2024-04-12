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
            var returnobject = new
            {
                ClaimsList = new List<string>(),
                UserIdentity = User.Identity.Name,
            };
            foreach (var item in User.Claims)
            {
                returnobject.ClaimsList.Add(
                    item.ToString() + " " +
                    item.Value.ToString() + " " +
                    item.ValueType.ToString());
            }


            return Ok(returnobject);
        }

        [AllowAnonymous]
        [HttpGet("/getallusers")]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                return Ok(await _testService.GetAllUsers());
            }
            catch (Exception e)
            {
                return BadRequest(new { Error = e.Message });
            }
        }

        [HttpPost("/newcustomer")]
        public async Task<IActionResult> CreateCustomer(UserCreate newUser)
        {
            try
            {
                if (newUser == null) return BadRequest();

                var result = await _userService.CreateCustomer(newUser);

                if (result.Succeeded)
                    return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new { Error = e.Message });
            }

            return BadRequest("what");
        }
        [AllowAnonymous]
        [HttpPost("/createadmin")]
        public async Task<IActionResult> CreateAdmin(UserCreate newAdmin)
        {
            try
            {
                var res = await _userService.CreateAdmin(newAdmin);
                if (res.Succeeded)
                    return Ok(res);

                return BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(new { Error = e.Message });
            }
        }
    }
}
