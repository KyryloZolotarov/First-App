using Infrastructure.Services.Interfaces;
using ListCard.Data.Requests;
using ListCard.Data.Responses;
using ListCard.Repositories.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Options;
using System.Collections.Generic;

namespace ListCard.Repositories
{
    public class ListRepository : IListRepository
    {
        private readonly IHttpClientService _httpClient;
        private readonly IOptions<AppSettings> _settings;

        public ListRepository(IHttpClientService httpClient, IOptions<AppSettings> settings)
        {
            _httpClient = httpClient;
            _settings = settings;
        }

        public async Task<int> AddListAsync(AddListRequest list)
        {
            return await _httpClient.SendAsync<int, AddListRequest>(
                $"{_settings.Value.ListUrl}/lists/",
            HttpMethod.Post, list);
        }

        public async Task DeleteListAsync(int id)
        {
            await _httpClient.SendAsync(
                $"{_settings.Value.ListUrl}/lists/{id}",
            HttpMethod.Delete);
        }

        public async Task<List<ListResponse>> GetListsAsync(string userId)
        {
            var result = await _httpClient.SendAsync<IEnumerable<ListResponse>, string>(
                $"{_settings.Value.ListUrl}/lists/",
            HttpMethod.Get, userId);
            return result.ToList();
        }

        public async Task PatchListAsync(int id, JsonPatchDocument<UpdateListRequest> list)
        {
            await _httpClient.SendAsync(
                $"{_settings.Value.ListUrl}/lists/{id}",
            HttpMethod.Patch, list);
        }
    }
}
