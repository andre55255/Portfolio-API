using AutoMapper;
using Portfolio.Communication.ViewObjects.Configuration;
using Portfolio.Communication.ViewObjects.Utlis;
using Portfolio.Core.Entities.Sql;

namespace Portfolio.Core.Profiles
{
    public class ConfigurationProfile : Profile
    {
        public ConfigurationProfile()
        {
            CreateMap<Configuration, Configuration>()
                .ReverseMap();

            CreateMap<Configuration, Configuration>()
                .ReverseMap();

            CreateMap<ConfigurationVO, Configuration>()
                .ReverseMap();

            CreateMap<SaveConfigurationVO, Configuration>()
                .ReverseMap();

            CreateMap<ListAllEntityVO<Configuration>, ListAllEntityVO<ConfigurationVO>>()
                .ReverseMap();
        }
    }
}
