using AutoMapper;
using BankApp.Domain.DTO;
using BankApp.Domain.Entities;

namespace BankApp.Domain.Profiles
{
    public class DispositionProfile : Profile
    {
        public DispositionProfile()
        {
            CreateMap<AccountCreateModel, Disposition>()
                .ForMember(dest => dest.Type, opt =>
                opt.MapFrom(src => src.DispositionType));
        }
    }
}
// Frequency can be monthly or weekly.
//public string Frequency { get; set; } = null!;
//public decimal Balance { get; set; }
//public int CustomerId { get; set; }
//// OWNER if main account. DISPONENT if extra added account.
//public string DispositionType { get; set; } = null!;
//public int? AccountTypesId { get; set; }

// hela disposition
//public int CustomerId { get; set; }
//public int AccountId { get; set; }
//public string Type { get; set; } = null!;
//public virtual Account Account { get; set; } = null!;
//public virtual ICollection<Card> Cards { get; set; } = new List<Card>();
//public virtual Customer Customer { get; set; } = null!;