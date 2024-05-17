using AutoMapper;
using History.Host.Data.Entities;
using History.Host.Models.Dtos;
using History.Host.Models.Requests;

namespace TestCatalog.Host.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {

            CreateMap<RecordDto, RecordEntity>().ReverseMap();
            CreateMap<RecordRequest, RecordEntity>();
        }
    }
}
