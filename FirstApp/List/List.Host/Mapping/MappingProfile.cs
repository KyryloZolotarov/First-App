using AutoMapper;
using List.Host.Data.Entities;
using List.Host.Models.Dtos;
using List.Host.Models.Requests;

namespace TestCatalog.Host.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ListDto, ListEntity>().ReverseMap();
            CreateMap<AddListRequest, ListEntity>().ReverseMap();
            CreateMap<UpdateListRequest, ListEntity>().ReverseMap();
        }
    }
}
