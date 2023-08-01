using AutoMapper;
using Portfolio.Communication.ViewObjects.Project;
using Portfolio.Communication.ViewObjects.Utlis;
using Portfolio.Core.Entities.Sql;

namespace Portfolio.Core.Profiles
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<Project, Project>()
                .ReverseMap();

            CreateMap<Project, SaveProjectVO>()
                .ReverseMap();

            CreateMap<ProjectReturnVO, Project>();

            CreateMap<Project, ProjectReturnVO>()
                .ForMember(x => x.PortfolioTitle, x => x.MapFrom(x => x.Portfolio.Title))
                .AfterMap((src, dest) =>
                {
                    if (!string.IsNullOrEmpty(src.Techs))
                    {
                        dest.TechsList =
                            src.Techs
                               .Split(',')
                               .Where(x => !string.IsNullOrEmpty(x))
                               .ToList();
                    }
                });

            CreateMap<SaveProjectVO, ProjectReturnVO>()
                .ReverseMap();

            CreateMap<ListAllEntityVO<Project>, ListAllEntityVO<ProjectReturnVO>>()
                .ReverseMap();
        }
    }
}
