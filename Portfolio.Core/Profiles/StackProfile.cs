using AutoMapper;
using Portfolio.Communication.ViewObjects.Stacks;
using Portfolio.Communication.ViewObjects.Utlis;
using Portfolio.Core.Entities.Sql;

namespace Portfolio.Core.Profiles
{
    public class StackProfile : Profile
    {
        public StackProfile()
        {
            CreateMap<Stack, Stack>()
                .ReverseMap();

            CreateMap<SaveStackVO, Stack>()
                .ReverseMap();

            CreateMap<Stack, StackReturnVO>()
                .ForMember(x => x.PortfolioTitle, x => x.MapFrom(x => x.Portfolio.Title))
                .ReverseMap();

            CreateMap<StackReturnVO, SaveStackVO>()
                .ReverseMap();

            CreateMap<ListAllEntityVO<Stack>, ListAllEntityVO<StackReturnVO>>()
                .ReverseMap();
        }
    }
}
