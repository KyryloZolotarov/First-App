using History.Host.Data.Entities;
using History.Host.Models.Requests;
using History.Host.Models.Responses;

namespace History.Host.Repositories.Interfaces
{
    public interface IHistoryRepository
    {
        Task<PaginatedRecordsResponse<RecordEntity>> GetUserRecordsAsync(PaginatedRecordsRequest<string> param);
        Task<PaginatedRecordsResponse<RecordEntity>> GetCardRecordsAsync(PaginatedRecordsRequest<int> param);
        Task AddRecordAsync(RecordEntity record);
        Task AddRecordsAsync(List<RecordEntity> records);
    }
}
