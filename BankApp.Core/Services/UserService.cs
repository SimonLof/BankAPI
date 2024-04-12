using AutoMapper;
using BankApp.Core.Interfaces;
using BankApp.Data.Identity;
using BankApp.Data.Interfaces;
using BankApp.Domain.DTO;
using BankApp.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace BankApp.Core.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserRepo _userRepo;
        private readonly IMapper _mapper;
        private readonly IAccountService _accountService;

        public UserService(UserManager<ApplicationUser> userManager, IUserRepo userRepo, IMapper mapper, IAccountService accountService)
        {
            _userManager = userManager;
            _userRepo = userRepo;
            _mapper = mapper;
            _accountService = accountService;
        }

        public async Task<IdentityResult> CreateCustomer(UserCreate user)
        {
            var result = await _userManager.CreateAsync(new ApplicationUser
            {
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            },
            user.Password);

            if (result.Succeeded)
            {
                var currentUser = await _userManager.FindByNameAsync(user.UserName);

                var roleResult = await _userManager.AddToRoleAsync(currentUser, "Customer");

                var newCustomer = _mapper.Map<Customer>(user);

                await _userRepo.AddNewCustomer(newCustomer);
                currentUser.Customer = newCustomer;

                var updateResult = await _userManager.UpdateAsync(currentUser);

                if (updateResult.Succeeded)
                {
                    var newAccount = new AccountCreate
                    {
                        AccountTypesId = AccountTypeEnum.StandardTransactionAccount,
                        Balance = 0,
                        CustomerId = newCustomer.CustomerId,
                        DispositionType = "OWNER",
                        Frequency = "Monthly"
                    };
                    await _accountService.CreateAccount(newAccount);
                }


                if (updateResult.Succeeded)
                    return roleResult;
                else throw new Exception(updateResult.Errors.First().Description);
            }


            throw new Exception(result.Errors.First().Description);
        }

        public async Task<IdentityResult> CreateAdmin(UserCreate user)
        {
            var result = await _userManager.CreateAsync(new ApplicationUser
            {
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            },
            user.Password);

            if (result.Succeeded)
            {
                var currentUser = await _userManager.FindByNameAsync(user.UserName);

                var roleResult = await _userManager.AddToRoleAsync(currentUser, "Administrator");

                return roleResult;
            }

            return result;
        }
    }
}
