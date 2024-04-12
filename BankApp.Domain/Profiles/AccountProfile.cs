using AutoMapper;
using BankApp.Domain.DTO;
using BankApp.Domain.Entities;

namespace BankApp.Domain.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<AccountCreate, Account>()
                .ForMember(dest => dest.AccountTypesId, opt =>
                opt.MapFrom(src => (int)src.AccountTypesId));

            CreateMap<Account, AccountSimpleView>()
                .ForMember(dest => dest.AccountType, opt =>
                opt.MapFrom(src => src.AccountTypesId == 1 ? "Standard transaction account" : "Savings account"));

            CreateMap<Account, AccountDetailedView>()
                .ForMember(dest => dest.AccountType, opt =>
                opt.MapFrom(src => src.AccountTypesId == 1 ? "Standard transaction account" : "Savings account"));
        }
    }
}


