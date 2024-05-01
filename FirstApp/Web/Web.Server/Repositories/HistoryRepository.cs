using Infrastructure.Services.Interfaces;
using Microsoft.Extensions.Options;
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
    }
}
