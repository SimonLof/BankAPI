using BankApp.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BankApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ITestService _testService;

        public AdminController(ITestService testService)
        {
            _testService = testService;
        }

        [HttpGet]
        public async Task<IActionResult> Testing()
        {
            return Ok(await _testService.GetFirstAccount());
        }
    }
}
