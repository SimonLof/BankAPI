using AutoMapper;
using BankApp.Domain.DTO;
using BankApp.Domain.Entities;

namespace BankApp.Domain.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<AccountCreateModel, Account>();
        }
    }
}