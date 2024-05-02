using AutoMapper;
using ListCard.Data.Dtos;
using ListCard.Data.Requests;
using ListCard.Data.Responses;
using ListCard.Repositories.Interfaces;
using ListCard.Services.Interfaces;
using Microsoft.AspNetCore.JsonPatch;

namespace ListCard.Services
{
    public class ListService : IListService
    {
        private readonly ICardRepository _cardRepository;
        private readonly IListRepository _listRepository;

        private readonly IMapper _mapper;

        public ListService(ICardRepository cardRepository, IListRepository listRepository, IMapper mapper)
        {
            _cardRepository = cardRepository;
            _mapper = mapper;
            _listRepository = listRepository;
        }

        public async Task AddListAsync(AddListRequest list)
        {
            await _listRepository.AddListAsync(list);
        }

        public async Task DeleteListAsync(int id)
        {
            await _listRepository.DeleteListAsync(id);
            await _cardRepository.DeleteCardsByListAsync(id);
        }

        public async Task<UserListDto> GetListsAsync(string userId)
        {
            var lists = await _listRepository.GetListsAsync(userId);
            var userLists = new UserListDto() { UserId = userId, Lists = new List<ListDto>() };
            foreach (var list in lists)
            {
                var cards = await _cardRepository.GetCardsAsync(list.Id);
                userLists.Lists.Add(new ListDto() { UserId = list.UserId, Title = list.Title, Id = list.Id, Cards = cards } );
            }
            return userLists;
        }

        public async Task PatchListAsync(int id, JsonPatchDocument<UpdateListRequest> list)
        {
            await _listRepository.PatchListAsync(id, list);
        }
    }
}
