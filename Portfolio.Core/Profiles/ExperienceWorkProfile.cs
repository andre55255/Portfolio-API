using AutoMapper;
using Portfolio.Communication.ViewObjects.ExperienceWork;
using Portfolio.Communication.ViewObjects.Utlis;
using Portfolio.Core.Entities.Sql;

namespace Portfolio.Core.Profiles
{
    public class ExperienceWorkProfile : Profile
    {
        public ExperienceWorkProfile()
        {
            CreateMap<ExperienceWork, ExperienceWork>()
                .ReverseMap();

            CreateMap<SaveExperienceWorkVO, ExperienceWork>();

            CreateMap<ExperienceWork, SaveExperienceWorkVO>();

            CreateMap<ExperienceWork, ExperienceWorkReturnVO>()
                .ForMember(x => x.PortfolioTitle, x => x.MapFrom(x => x.Portfolio.Title))
                .ForMember(x => x.JourneyWorkStatusName, x => x.MapFrom(x => x.JourneyWorkStatus.Value));

            CreateMap<ExperienceWorkReturnVO, SaveExperienceWorkVO>()
                .ReverseMap();

            CreateMap<ListAllEntityVO<ExperienceWork>, ListAllEntityVO<ExperienceWorkReturnVO>>()
               .ReverseMap();
        }
    }
}
