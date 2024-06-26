﻿using BankApp.Core.Interfaces;
using BankApp.Data.Identity;
using BankApp.Data.Interfaces;
using BankApp.Domain.Entities;

namespace BankApp.Core.Services
{
    public class TestService : ITestService
    {
        private readonly ITestRepo _repo;

        public TestService(ITestRepo repo)
        {
            _repo = repo;
        }

        public async Task<Account> GetFirstAccount()
        {
            return await _repo.GetFirstAccount();
        }

        public async Task<List<ApplicationUser>> GetAllUsers()
        {
            return await _repo.GetAllUsers();
        }
    }
}
