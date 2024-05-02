using Infrastructure.Services.Interfaces;
using Microsoft.Extensions.Options;
using Web.Server.Data.Dtos;
using Web.Server.Data.Requests;
using Web.Server.Data.Responses;
using Web.Server.Repositories.Interfaces;

namespace Web.Server.Repositories
{
    public class HistoryRepository : IHistoryRepository
    {
        private readonly IHttpClientService _httpClient;
        private readonly IOptions<AppSettings> _settings;

        public HistoryRepository(IHttpClientService httpClient, IOptions<AppSettings> settings)
        {
            _httpClient = httpClient;
            _settings = settings;
        }

        public async Task AddRecordAsync(RecordRequest record)
        {
            await _httpClient.SendAsync<RecordRequest>(
                $"{_settings.Value.HistoryUrl}/history/",
            HttpMethod.Post, record);
        }

        public async Task<PaginatedRecordsResponse<RecordDto>> GetCardRecordsAsync(PaginatedRecordsRequest<int> param)
        {
            return await _httpClient.SendAsync<PaginatedRecordsResponse<RecordDto>, PaginatedRecordsRequest<int>>(
                $"{_settings.Value.HistoryUrl}/history/",
            HttpMethod.Get, param);
        }

        public async Task<PaginatedRecordsResponse<RecordDto>> GetUserRecordsAsync(PaginatedRecordsRequest<string> param)
        {
            return await _httpClient.SendAsync<PaginatedRecordsResponse<RecordDto>, PaginatedRecordsRequest<string>>(
                $"{_settings.Value.HistoryUrl}/history/",
            HttpMethod.Get, param);
        }
    }
}
