using AutoMapper;
using ListCard.Data.Dtos;
using ListCard.Data.Requests;
using ListCard.Repositories.Interfaces;
using ListCard.Services.Interfaces;

namespace ListCard.Services
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;

        private readonly IMapper _mapper;

        public CardService(ICardRepository cardRepository, IMapper mapper)
        {
            _mapper = mapper;
            _cardRepository = cardRepository;
        }

        public async Task AddCardAsync(CardRequest card)
        {
            await _cardRepository.AddCardAsync(card);
        }

        public async Task DeleteCardAsync(int id)
        {
            await _cardRepository.DeleteCardAsync(id);
        }

        public async Task<CardDto> GetCardAsync(int id)
        {
            return await _cardRepository.GetCardAsync(id);
            throw new NotImplementedException();
        }

        public async Task PatchCardAsync(int id, CardRequest card)
        {
            await _cardRepository.PatchCardAsync(id, card);
        }
    }
}
