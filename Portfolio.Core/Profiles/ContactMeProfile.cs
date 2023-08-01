using AutoMapper;
using Portfolio.Communication.ViewObjects.ContactMe;
using Portfolio.Communication.ViewObjects.Utlis;
using Portfolio.Core.Entities.Sql;

namespace Portfolio.Core.Profiles
{
    public class ContactMeProfile : Profile
    {
        public ContactMeProfile()
        {
            CreateMap<ContactMe, ContactMe>()
                .ReverseMap();

            CreateMap<ContactMe, SaveContactMeVO>()
                .ReverseMap();

            CreateMap<ContactMe, ContactMeReturnVO>()
                .ForMember(x => x.PortfolioTitle, x => x.MapFrom(x => x.Portfolio.Title))
                .ReverseMap();

            CreateMap<ListAllEntityVO<ContactMe>, ListAllEntityVO<ContactMeReturnVO>>()
             .ReverseMap();
        }
    }
}
