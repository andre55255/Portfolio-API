using AutoMapper;
using Portfolio.Communication.ViewObjects.Portfolio;
using Portfolio.Communication.ViewObjects.Utlis;
using Portfolio.Core.Entities.Sql;

namespace Portfolio.Core.Profiles
{
    public class PortfolioConfigProfile : Profile
    {
        public PortfolioConfigProfile()
        {
            CreateMap<PortfolioConfig, PortfolioConfig>()
                .ReverseMap();

            CreateMap<SavePortfolioVO, PortfolioConfig>();

            CreateMap<PortfolioConfig, SavePortfolioVO>()
                .ForMember(x => x.UsersIds, x => x.MapFrom(x => x.UsersAssociates.Select(x => x.Id).ToList()));

            CreateMap<PortfolioConfig, PortfolioReturnVO>()
                .ForMember(x => x.UsersIds, x => x.MapFrom(x => x.UsersAssociates.Select(x => x.Id).ToList()))
                .ForMember(x => x.UsersNameAssociates, x => x.MapFrom(x => x.UsersAssociates.Select(x => $"{x.FirstName} {x.LastName}")));

            CreateMap<PortfolioReturnVO, SavePortfolioVO>()
                .ReverseMap();

            CreateMap<ListAllEntityVO<PortfolioConfig>, ListAllEntityVO<PortfolioReturnVO>>()
               .ReverseMap();
        }
    }
}
