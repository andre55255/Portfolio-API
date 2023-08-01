using AutoMapper;
using Portfolio.Communication.ViewObjects.ExperienceEducation;
using Portfolio.Communication.ViewObjects.Utlis;
using Portfolio.Core.Entities.Sql;

namespace Portfolio.Core.Profiles
{
    public class ExperienceEducationProfile : Profile
    {
        public ExperienceEducationProfile()
        {
            CreateMap<ExperienceEducation, ExperienceEducation>()
               .ReverseMap();

            CreateMap<SaveExperienceEducationVO, ExperienceEducation>();

            CreateMap<ExperienceEducation, SaveExperienceEducationVO>();

            CreateMap<ExperienceEducation, ExperienceEducationReturnVO>()
                .ForMember(x => x.PortfolioTitle, x => x.MapFrom(x => x.Portfolio.Title))
                .ForMember(x => x.JourneyWorkStatusName, x => x.MapFrom(x => x.JourneyWorkStatus.Value));

            CreateMap<ExperienceEducationReturnVO, SaveExperienceEducationVO>()
                .ReverseMap();

            CreateMap<ListAllEntityVO<ExperienceEducation>, ListAllEntityVO<ExperienceEducationReturnVO>>()
               .ReverseMap();
        }
    }
}
