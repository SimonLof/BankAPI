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
        private readonly ITransactionService _transactionService;

        public CustomerController(IAccountService accountService, ITransactionService transactionService)
        {
            _accountService = accountService;
            _transactionService = transactionService;
        }

        [HttpPost("newaccount")]
        public async Task<IActionResult> OpenNewAccount(AccountCreateByCustomerDTO newAccount)
        {
            try
            {
                await _accountService.AccountCreateByCustomer(newAccount, User.Identity.Name);
                return Ok("Account created.");
            }
            catch (Exception e)
            {
                return BadRequest(new { Error = e.Message });
            }
        }

        [HttpGet("myaccounts")]
        public async Task<IActionResult> ShowMyAccounts()
        {
            try
            {
                var result = await _accountService.GetAccountsFromName(User.Identity.Name);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new { Error = e.Message });
            }
        }

        [HttpGet("account/{id}")]
        public async Task<IActionResult> GetSingleAccount(int id)
        {
            try
            {
                var result = await _accountService.CustomerGetAccountWithTransactions(id, User.Identity.Name);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new { Error = e.Message });
            }
        }

        [HttpPost("depositOrWithdraw")]
        public async Task<IActionResult> MakeTransaction(TransactionCreateDTO transaction)
        {
            try
            {
                var result = await _transactionService.CustomerSingleTransaction(transaction, User.Identity.Name);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new { Error = e.Message });
            }
        }

        [HttpPost("transfer")]
        public async Task<IActionResult> TransferMoney(TransactionBetweenAccountsCreateDTO transaction)
        {
            try
            {
                var result = await _transactionService.TransferTransaction(transaction, User.Identity.Name);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new { Error = e.Message });
            }
        }
    }
}
