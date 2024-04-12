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

        public UserService(UserManager<ApplicationUser> userManager, IUserRepo userRepo, IMapper mapper)
        {
            _userManager = userManager;
            _userRepo = userRepo;
            _mapper = mapper;
        }

        public async Task<IdentityResult> CreateCustomer(UserCreateModel user)
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

                // TODO fixa den här skiten. ny customer behöver _massa_ skit.
                await _userRepo.AddNewCustomer(newCustomer);
                currentUser.Customer = newCustomer;

                var updateResult = await _userManager.UpdateAsync(currentUser);
                if (updateResult.Succeeded)
                    return roleResult;
            }
            else throw new Exception(result.Errors.First().Description);

            throw new Exception("Something went wrong.");
        }

        public async Task<IdentityResult> CreateAdmin(UserCreateModel user)
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
