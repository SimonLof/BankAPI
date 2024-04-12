using AutoMapper;
using BankApp.Domain.DTO;
using BankApp.Domain.Entities;

namespace BankApp.Domain.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<UserCreate, Customer>()
                .ForMember(dest => dest.Emailaddress, opt =>
                opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Telephonenumber, opt =>
                opt.MapFrom(src => src.PhoneNumber));
        }
    }
}
