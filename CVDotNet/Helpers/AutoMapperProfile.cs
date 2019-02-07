using AutoMapper;
using CVDotNet.Dtos;
using CVDotNet.Models;

namespace CVDotNet.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}