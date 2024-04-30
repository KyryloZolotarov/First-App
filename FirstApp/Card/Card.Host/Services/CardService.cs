using AutoMapper;
using Card.Host.Data.Entities;
using Card.Host.Models.Dtos;
using Card.Host.Models.Requests;
using Card.Host.Repositories.Interfaces;
using Card.Host.Services.Interfaces;
using Infrastructure.Exceptions;
using Infrastructure.Services;
using Infrastructure.Services.Interfaces;
using Microsoft.Extensions.Logging;
using TestCatalog.Host.Data;

namespace Card.Host.Services
{
    public class CardService : BaseDataService<ApplicationDbContext>, ICardService
    {
        private readonly ICardRepository _cardRepository;

        private readonly IMapper _mapper;

        public CardService(ICardRepository cardRepository, IMapper mapper, IDbContextWrapper<ApplicationDbContext> dbContextWrapper, ILogger<BaseDataService<ApplicationDbContext>> logger)
        : base(dbContextWrapper, logger)
        {
            _mapper = mapper;
            _cardRepository = cardRepository;
        }

        public async Task AddCardAsync(CardRequest card)
        {
            await ExecuteSafeAsync(async () =>
            {
                var cardToDb = _mapper.Map<CardEntity>(card);
                await _cardRepository.AddCardAsync(cardToDb);
            });
        }

        public async Task DeleteCardAsync(int id)
        {
            await ExecuteSafeAsync(async () =>
            {
                var cardExists = await ExecuteSafeAsync(async () => await _cardRepository.GetCardAsync(id));

                if (cardExists == null) throw new BusinessException($"Card with id: {id} not found");
                await _cardRepository.DeleteCardAsync(cardExists);
            });
        }

        public async Task<CardDto> GetCardAsync(int id)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var card = await ExecuteSafeAsync(async () => await _cardRepository.GetCardAsync(id));
                if (card == null) throw new BusinessException($"Card with id: {id} not found");
                var cardResponse = _mapper.Map<CardDto>(card);
                return(cardResponse);
            });
        }

        public async Task<List<CardDto>> GetCardsAsync(int listId)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var cardsList = await ExecuteSafeAsync(async () => await _cardRepository.GetCardsAsync(listId));
                var cardsResponse = cardsList.Select(s => _mapper.Map<CardDto>(s)).ToList();
                return (cardsResponse);
            });
        }

        public async Task UpdateCardAsync(int id, CardRequest card)
        {
            await ExecuteSafeAsync(async () =>
            {
                var cardExists = await ExecuteSafeAsync(async () => await _cardRepository.GetCardAsync(id));

                if (cardExists == null) throw new BusinessException($"Card with id: {id} not found");
                if (card.DueDate != null &&  card.DueDate != cardExists.DueDate) cardExists.DueDate = card.DueDate;
                if(card.ListId != null && card.ListId != cardExists.ListId) cardExists.ListId = card.ListId;
                if(card.Priority != null && card.Priority != cardExists.Priority) cardExists.Priority = card.Priority;
                if(card.Name != null && card.Name != cardExists.Name) cardExists.Name = card.Name;
                if(card.Description != null && card.Description != cardExists.Description) cardExists.Description = card.Description;
                await _cardRepository.UpdateCardAsync(cardExists);
            });
        }
    }
}
