using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Web.Server.Data.Models;
using Web.Server.Data.Requests;
using Web.Server.Repositories.Interfaces;
using Web.Server.Services.Interfaces;

namespace Web.Server.Services
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;
        private readonly IHistoryRepository _historyRepository;
        private readonly IMapper _mapper;

        public CardService(ICardRepository cardRepository, IHistoryRepository historyRepository, IMapper mapper)
        {
            _cardRepository = cardRepository;
            _historyRepository = historyRepository;
            _mapper = mapper;
    }

        public async Task AddCardAsync(AddCardRequest card)
        {
            await _cardRepository.AddCardAsync(card);
        }

        public async Task DeleteCardAsync(int id)
        {
            await _cardRepository.DeleteCardAsync(id);
        }

        public async Task<CardModel> GetCardAsync(int id)
        {

            var card = await _cardRepository.GetCardAsync(id);
            return _mapper.Map<CardModel>(card);
        }

        public async Task PatchCardAsync(int id, JsonPatchDocument<UpdateCardRequest> card)
        {
            await _cardRepository.PatchCardAsync(id, card);
        }
    }
}
