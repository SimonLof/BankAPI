using AutoMapper;
using BankApp.Domain.DTO;
using BankApp.Domain.Entities;

namespace BankApp.Domain.Profiles
{
    public class LoanProfile : Profile
    {
        public LoanProfile()
        {
            CreateMap<Loan, LoanViewDTO>();

            CreateMap<LoanCreateDTO, Loan>();
        }
    }
}
