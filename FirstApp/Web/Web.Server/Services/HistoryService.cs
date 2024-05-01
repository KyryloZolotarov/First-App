using Web.Server.Repositories.Interfaces;
using Web.Server.Services.Interfaces;

namespace Web.Server.Services
{
    public class HistoryService : IHistoryService
    {
        private readonly IHistoryRepository _historyRepository;

        public HistoryService(IHistoryRepository historyRepository)
        {
            _historyRepository = historyRepository;
        }
    }
}
