using AutoMapper;
using Card.Host.Data.Entities;
using Card.Host.Models.Dtos;
using Card.Host.Models.Requests;
using Card.Host.Repositories.Interfaces;
using Card.Host.Services.Interfaces;
using Infrastructure.Exceptions;
using Infrastructure.Services;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
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

        public async Task AddCardAsync(AddCardRequest card)
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
                var cardExists = await _cardRepository.GetCardAsync(id);

                if (cardExists == null) throw new BusinessException($"Card with id: {id} not found");
                await _cardRepository.DeleteCardAsync(cardExists);
            });
        }
        public async Task DeleteCardsAsync(int id)
        {
            await ExecuteSafeAsync(async () =>
            {
                var cardsList = await _cardRepository.GetCardsAsync(id);
                if (cardsList == null) throw new BusinessException($"Cards with list id: {id} not found");                
                await _cardRepository.DeleteCardsAsync(cardsList);
            });
        }

        public async Task<CardDto> GetCardAsync(int id)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var card = await _cardRepository.GetCardAsync(id);
                if (card == null) throw new BusinessException($"Card with id: {id} not found");
                var cardResponse = _mapper.Map<CardDto>(card);
                return(cardResponse);
            });
        }

        public async Task<List<CardDto>> GetCardsAsync(int listId)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var cardsList =  await _cardRepository.GetCardsAsync(listId);
                if (cardsList == null) throw new BusinessException($"Cards with list id: {listId} not found");
                var cardsResponse = cardsList.Select(s => _mapper.Map<CardDto>(s)).ToList();
                return (cardsResponse);
            });
        }

        public async Task PatchCardAsync(int id, JsonPatchDocument<UpdateCardRequest> card)
        {
            await ExecuteSafeAsync(async () =>
            {
                var cardExists = _mapper.Map<UpdateCardRequest>( await _cardRepository.GetCardAsync(id));
                if (cardExists == null) throw new BusinessException($"Card with id: {id} not found");
                card.ApplyTo(cardExists);
                var updatedCard = _mapper.Map<CardEntity>(cardExists);
                updatedCard.Id = id;
                await _cardRepository.UpdateCardAsync(updatedCard);
            });
        }
    }
}
