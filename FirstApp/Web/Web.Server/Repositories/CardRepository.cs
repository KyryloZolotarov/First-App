using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Options;
using Web.Server.Data.Requests;
using Web.Server.Repositories.Interfaces;

namespace Web.Server.Repositories
{
    public class CardRepository
    {
        private readonly IHttpClientService _httpClient;
        private readonly IOptions<AppSettings> _settings;

        public CardRepository(IHttpClientService httpClient, IOptions<AppSettings> settings)
        {
            _httpClient = httpClient;
            _settings = settings;
        }
        public async Task AddCardAsync(AddCardRequest card)
        {
            await _httpClient.SendAsync<AddCardRequest>(
                $"{_settings.Value.ListCardUrl}/cards/",
            HttpMethod.Post, card);
        }

        public async Task DeleteCardAsync(int id)
        {
            await _httpClient.SendAsync(
                $"{_settings.Value.ListCardUrl}/cards/{id}",
            HttpMethod.Delete);
        }
        public async Task<CardDto> GetCardAsync(int id)
        {
            return await _httpClient.SendAsync<CardDto>(
                $"{_settings.Value.ListCardUrl}/cards/{id}",
            HttpMethod.Get);
        }

        public async Task PatchCardAsync(int id, JsonPatchDocument<UpdateCardRequest> card)
        {
            await _httpClient.SendAsync(
                $"{_settings.Value.ListCardUrl}/cards/{id}",
            HttpMethod.Patch, card);
        }
    }
}
