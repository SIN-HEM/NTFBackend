using AutoMapper;
using NIFTWebApp.Modules.UserModule.DTOs;
using NIFTWebApp.Modules.UserModule.Entities;

namespace NIFTWebApp.Modules.UserModule.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<CreateUserDto, User>();
            CreateMap<UpdateUserDto, User>();
        }
    }
}
