using Infrastructure.Services.Interfaces;
using Microsoft.Extensions.Options;
using Web.Server.Data.Requests;
using Web.Server.Repositories.Interfaces;

namespace Web.Server.Repositories
{
    public class ListCardRepository : IListCardRepository
    {
        private readonly IHttpClientService _httpClient;
        private readonly IOptions<AppSettings> _settings;

        public ListCardRepository(IHttpClientService httpClient, IOptions<AppSettings> settings)
        {
            _httpClient = httpClient;
            _settings = settings;
        }

        public async Task AddCardAsync(CardRequest card)
        {
            await _httpClient.SendAsync<CardRequest>(
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

        public async Task<List<CardDto>> GetCardsAsync(int listId)
        {
            var result = await _httpClient.SendAsync<IEnumerable<CardDto>, int>(
                $"{_settings.Value.ListCardUrl}/cards/",
            HttpMethod.Get, listId);
            return result.ToList();
        }

        public async Task PatchCardAsync(int id, CardRequest card)
        {
            await _httpClient.SendAsync(
                $"{_settings.Value.ListCardUrl}/cards/{id}",
            HttpMethod.Patch, card);
        }

        public async Task AddListAsync(ListRequest list)
        {
            await _httpClient.SendAsync<ListRequest>(
                $"{_settings.Value.ListCardUrl}/lists/",
            HttpMethod.Post, list);
        }

        public async Task DeleteListAsync(int id)
        {
            await _httpClient.SendAsync(
                $"{_settings.Value.ListCardUrl}/lists/{id}",
            HttpMethod.Delete);
        }

        public async Task<UserListDto> GetListAsync(string userId)
        {
            return await _httpClient.SendAsync<UserListDto, string>(
                $"{_settings.Value.ListCardUrl}/lists/",
            HttpMethod.Get, userId);
        }

        public async Task PatchListAsync(int id, ListRequest list)
        {
            await _httpClient.SendAsync(
                $"{_settings.Value.ListCardUrl}/lists/{id}",
            HttpMethod.Patch, list);
        }
    }
}
