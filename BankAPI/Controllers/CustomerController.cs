﻿using BankApp.Core.Interfaces;
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

        [HttpGet("myaccounts")]
        public async Task<IActionResult> ShowMyAccounts()
        {
            var result = await _accountService.GetAccountsFromName(User.Identity.Name);
            return Ok(result);
        }

        [HttpGet("account/{id}")]
        public async Task<IActionResult> GetSingleAccount(int id)
        {
            try
            {
                var result = await _accountService.CustomerGetAcountWithTransactions(id, User.Identity.Name);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(new { Error = e.Message });
            }
        }

        [HttpPost("depositOrWithdraw")]
        public async Task<IActionResult> MakeTransaction(TransactionCreate transaction)
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
        public async Task<IActionResult> TransferMoney(TransactionBetweenAccountsCreate transaction)
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
