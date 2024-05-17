using AutoMapper;
using User.Host.Data.Entities;
using User.Host.Models.Dtos;
using User.Host.Models.UserRequests;

namespace TestCatalog.Host.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDto, UserEntity>().ReverseMap();
            CreateMap<UserRequest, UserEntity>();
        }
    }
}
