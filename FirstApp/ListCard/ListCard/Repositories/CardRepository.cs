using Infrastructure.Services.Interfaces;
using ListCard.Data.Dtos;
using ListCard.Data.Requests;
using ListCard.Repositories.Interfaces;
using Microsoft.Extensions.Options;
using System.Net.Http;

namespace ListCard.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly IHttpClientService _httpClient;
        private readonly IOptions<AppSettings> _settings;

        public CardRepository(IHttpClientService httpClient,  IOptions<AppSettings> settings)
        {
            _httpClient = httpClient;
            _settings = settings;
        }
        public async Task AddCardAsync(CardRequest card)
        {
            await _httpClient.SendAsync<CardRequest>(
                $"{_settings.Value.CardUrl}/cards/",
            HttpMethod.Post, card);
        }

        public async Task DeleteCardAsync(int id)
        {
            await _httpClient.SendAsync(
                $"{_settings.Value.CardUrl}/cards/{id}",
            HttpMethod.Delete);
        }

        public async Task<CardDto> GetCardAsync(int id)
        {
            return await _httpClient.SendAsync<CardDto>(
                $"{_settings.Value.CardUrl}/cards/{id}",
            HttpMethod.Get);
        }

        public async Task<List<CardDto>> GetCardsAsync(int listId)
        {
            var result = await _httpClient.SendAsync<IEnumerable<CardDto>, int>(
                $"{_settings.Value.CardUrl}/cards/",
            HttpMethod.Get, listId);
            return result.ToList();
        }

        public async Task PatchCardAsync(int id, CardRequest card)
        {
            await _httpClient.SendAsync(
                $"{_settings.Value.CardUrl}/cards/{id}",
            HttpMethod.Patch, card);
        }
    }
}
