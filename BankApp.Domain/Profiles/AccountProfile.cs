using AutoMapper;
using BankApp.Domain.DTO;
using BankApp.Domain.Entities;

namespace BankApp.Domain.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<AccountCreateDTO, Account>()
                .ForMember(dest => dest.AccountTypesId, opt =>
                opt.MapFrom(src => (int)src.AccountTypesId));

            CreateMap<Account, AccountSimpleViewDTO>()
                .ForMember(dest => dest.AccountType, opt =>
                opt.MapFrom(src => src.AccountTypesId == 1 ? "Standard transaction account" : "Savings account"));

            CreateMap<Account, AccountDetailedViewDTO>()
                .ForMember(dest => dest.AccountType, opt =>
                opt.MapFrom(src => src.AccountTypesId == 1 ? "Standard transaction account" : "Savings account"));
        }
    }
}


