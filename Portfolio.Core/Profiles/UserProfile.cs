using AutoMapper;
using Portfolio.Communication.ViewObjects.Account;
using Portfolio.Communication.ViewObjects.User;
using Portfolio.Communication.ViewObjects.Utlis;
using Portfolio.Core.Entities.Identity;

namespace Portfolio.Core.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<AspNetUser, UserWithRolesVO>()
                .ReverseMap();

            CreateMap<AspNetUser, UserInfoVO>()
                .ReverseMap();

            CreateMap<UserWithRolesVO, SaveUserVO>()
                .ReverseMap();

            CreateMap<RegisterUserVO, SaveUserVO>()
                .ReverseMap();

            CreateMap<SaveUserVO, AspNetUser>()
                .ForMember(x => x.NormalizedUserName, x => x.MapFrom(x => x.UserName.ToUpper()))
                .ForMember(x => x.NormalizedEmail, x => x.MapFrom(x => x.Email.ToUpper()))
                .ForMember(x => x.PasswordHash, x => x.MapFrom(x => x.Password))
                .AfterMap((src, dest) =>
                {
                    dest.EmailConfirmed = true;
                    dest.PhoneNumberConfirmed = true;
                })
                .ReverseMap();

            CreateMap<ListAllEntityVO<AspNetUser>, ListAllEntityVO<UserInfoVO>>()
                            .ReverseMap();
        }
    }
}
