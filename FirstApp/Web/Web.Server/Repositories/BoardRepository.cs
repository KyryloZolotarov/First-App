using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.Extensions.Options;
using Web.Server.Data.Dtos;
using Web.Server.Data.Requests;
using Web.Server.Repositories.Interfaces;

namespace Web.Server.Repositories
{
    public class BoardRepository : IBoardRepository
    {
        private readonly IHttpClientService _httpClient;
        private readonly IOptions<AppSettings> _settings;

        public BoardRepository(IHttpClientService httpClient, IOptions<AppSettings> settings)
        {
            _httpClient = httpClient;
            _settings = settings;
        }

        public async Task<int> AddBoardAsync(AddBoardRequest board)
        {
            return await _httpClient.SendAsync<int, AddBoardRequest>(
                $"{_settings.Value.BoardUrl}/boards/",
            HttpMethod.Post, board);
        }

        public async Task DeleteBoardAsync(int id)
        {
            await _httpClient.SendAsync(
                $"{_settings.Value.BoardUrl}/boards/{id}",
            HttpMethod.Delete);
        }

        public async Task<IEnumerable<BoardDto>> GetBoardsAsync(string userId)
        {
            return await _httpClient.SendAsync<IEnumerable<BoardDto>, string>(
                $"{_settings.Value.BoardUrl}/boards/",
            HttpMethod.Get, userId);
        }

        public async Task PatchBoardAsync(int id, JsonPatchDocument<UpdateBoardRequest> board)
        {
            await _httpClient.SendAsync(
                $"{_settings.Value.BoardUrl}/boards/{id}",
            HttpMethod.Patch, board);
        }
    }
}
