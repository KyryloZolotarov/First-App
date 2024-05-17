using AutoMapper;
using Board.Host.Data.Entities;
using Board.Host.Models.Dtos;
using Board.Host.Models.Requests;

namespace Board.Host.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BoardDto, BoardEntity>().ReverseMap();
            CreateMap<AddBoardRequest, BoardEntity>().ReverseMap();
            CreateMap<UpdateBoardRequest, BoardEntity>().ReverseMap();
        }
    }
}
