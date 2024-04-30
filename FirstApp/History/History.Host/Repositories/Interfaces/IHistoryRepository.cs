using History.Host.Data.Entities;

namespace History.Host.Repositories.Interfaces
{
    public interface IHistoryRepository
    {
        Task<List<RecordEntity>> GetRecordsAsync(string userId);
        Task AddRecordAsync(RecordEntity record);
    }
}
