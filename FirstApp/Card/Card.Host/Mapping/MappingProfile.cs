using AutoMapper;
using Card.Host.Data.Entities;
using Card.Host.Models.Dtos;
using Card.Host.Models.Requests;

namespace TestCatalog.Host.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<CardDto, CardEntity>().ReverseMap();
            CreateMap<AddCardRequest, CardEntity>().ReverseMap();
            CreateMap<UpdateCardRequest, CardEntity>().ReverseMap();
        }
    }
}
