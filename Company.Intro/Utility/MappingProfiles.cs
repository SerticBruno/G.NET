using AutoMapper;
using Company.Intro.DTOs;
using Company.Intro.Models;

namespace Company.Intro.Utility
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
