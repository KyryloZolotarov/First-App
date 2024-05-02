using AutoMapper;
using Web.Server.Data.Dtos;
using Web.Server.Data.Models;
using Web.Server.Repositories.Interfaces;

namespace Web.Server.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LoginDto, LoginModel>().ReverseMap();
            CreateMap<UserDto, UserModel>().ReverseMap();
            CreateMap<CardDto,  CardModel>().ReverseMap();
            CreateMap<ListDto, ListModel>().ReverseMap();
            CreateMap<UserListDto, UserListModel>().ReverseMap();
            CreateMap<RecordDto, RecordModel>().ReverseMap();
        }
    }
}
