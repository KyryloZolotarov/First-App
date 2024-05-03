﻿using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using System.Collections.Generic;
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

        public async Task AddCardAsync(string userId, AddCardRequest card)
        {
            await _cardRepository.AddCardAsync(card);
            var record = new RecordRequest();
            record.DateTime = DateTime.Now;
            record.Property = "Card";
            record.UserId = userId;
            record.Event = OperationType.Add;
            record.Destination = card.Name;
            await _historyRepository.AddRecordAsync(record);
        }

        public async Task DeleteCardAsync(string userId, DeleteCardRequest card)
        {
            await _cardRepository.DeleteCardAsync(card.Id);
            var record = new RecordRequest();
            record.DateTime = DateTime.Now;
            record.Property = "Card";
            record.UserId = userId;
            record.Event = OperationType.Remove;
        }

        public async Task<CardModel> GetCardAsync(int id)
        {

            var card = await _cardRepository.GetCardAsync(id);
            return _mapper.Map<CardModel>(card);
        }

        public async Task PatchCardAsync(int cardId, string userId, JsonPatchDocument<UpdateCardRequest> card)
        {
            await _cardRepository.PatchCardAsync(cardId, card);
            var operations = card.Operations;
            var records = new List<RecordRequest>();
            foreach (var op in operations)
            {
                records.Add(new RecordRequest { CardId = cardId, DateTime = DateTime.Now, Event = op.OperationType, Property = op.path, Destination = (string)op.value, Origin = op.from, UserId = userId });
            }
            await _historyRepository.AddRecordsAsync(records);
        }
    }
}
