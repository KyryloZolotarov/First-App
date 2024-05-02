using History.Host.Data.Entities;
using History.Host.Models.Dtos;
using History.Host.Models.Requests;
using History.Host.Models.Responses;

namespace History.Host.Services.Interfaces
{
    public interface IHistoryService
    {
        Task<PaginatedRecordsResponse<RecordDto>> GetUserRecordsAsync(PaginatedRecordsRequest<string> param);
        Task<PaginatedRecordsResponse<RecordDto>> GetCardRecordsAsync(PaginatedRecordsRequest<int> param);
        Task AddRecordAsync(RecordRequest record);
        Task AddRecordsAsync(List<RecordRequest> records);
    }
}
