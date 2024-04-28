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
        private readonly IAccountService _accountService;
        private readonly ILoanService _loanService;

        public AdminController(ITestService testService,
                               IUserService userService,
                               IAccountService accountService,
                               ILoanService loanService)
        {
            _testService = testService;
            _userService = userService;
            _accountService = accountService;
            _loanService = loanService;
        }

        [AllowAnonymous]
        [HttpGet("whoami")]
        public async Task<IActionResult> WhoAmI()
        {
            try
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
            catch (Exception e)
            {
                return BadRequest(new { Error = e.Message });
            }
        }

        [AllowAnonymous]
        [HttpGet("getallusers")]
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

        [HttpPost("newloan")]
        public async Task<IActionResult> NewLoan(LoanCreateDTO loan)
        {
            try
            {
                var newLoan = await _loanService.CreateNewLoan(loan);
                return Ok(newLoan);
            }
            catch (Exception e)
            {

                return BadRequest(new { Error = e.Message });
            }
        }

        [HttpGet("customer/{name:alpha}")]
        public async Task<IActionResult> GetCustomerAccounts(string name)
        {
            try
            {
                var result = await _accountService.GetAccountsFromName(name);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new { Error = e.Message });
            }
        }


        [HttpPost("newcustomer")]
        public async Task<IActionResult> CreateCustomer(UserCreateDTO newUser)
        {
            try
            {
                if (newUser == null) return BadRequest();

                var result = await _userService.CreateCustomer(newUser);

                if (result.Succeeded)
                    return Ok("Customer created.");

                return BadRequest(new { Error = result.Errors.First().Description });
            }
            catch (Exception e)
            {
                return BadRequest(new { Error = e.Message });
            }
        }
        [AllowAnonymous]
        [HttpPost("createadmin")]
        public async Task<IActionResult> CreateAdmin(UserCreateDTO newAdmin)
        {
            try
            {
                var res = await _userService.CreateAdmin(newAdmin);
                if (res.Succeeded)
                    return Ok(res);

                return BadRequest(new { Error = res.Errors.First().Description });
            }
            catch (Exception e)
            {
                return BadRequest(new { Error = e.Message });
            }
        }
    }
}
