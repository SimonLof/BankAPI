using BankApp.Core.Interfaces;
using BankApp.Domain.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Customer")]
    public class CustomerController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public CustomerController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("/newaccount")]
        public async Task<IActionResult> OpenNewAccount(AccountCreateCustomer newAccount)
        {
            try
            {
                await _accountService.UserCreateAccount(newAccount, User.Identity.Name);
                return Ok("Account created.");
            }
            catch (Exception e)
            {
                return BadRequest(new { Error = e.Message });
            }
        }

        [HttpGet("/myaccounts")]
        public async Task<IActionResult> ShowMyAccounts()
        {
            var result = await _accountService.GetAccounts(User.Identity.Name);
            return Ok(result);
        }
    }
}


//public string Frequency { get; set; } = null!;
//public decimal Balance { get; set; }
//public int CustomerId { get; set; }
//// OWNER if main account. DISPONENT if extra added account.
//public string DispositionType { get; set; } = null!;
//public AccountTypeEnum? AccountTypesId { get; set; }