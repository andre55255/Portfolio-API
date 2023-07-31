using AutoMapper;
using Portfolio.Communication.ViewObjects.GenericTypes;
using Portfolio.Communication.ViewObjects.Utlis;
using Portfolio.Core.Entities.Sql;

namespace Portfolio.Core.Profiles
{
    public class GenericTypeProfile : Profile
    {
        public GenericTypeProfile()
        {
            CreateMap<SaveGenericTypeVO, GenericType>()
                .ReverseMap();

            CreateMap<GenericType, GenericType>()
                .ReverseMap();

            CreateMap<GenericType, GenericTypeVO>()
                .ReverseMap();

            CreateMap<ListAllEntityVO<GenericType>, ListAllEntityVO<GenericTypeVO>>()
                .ReverseMap();
        }
    }
}
