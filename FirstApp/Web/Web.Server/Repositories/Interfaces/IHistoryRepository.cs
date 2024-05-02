using Infrastructure.Services.Interfaces;
using Microsoft.Extensions.Options;
using Web.Server.Data.Dtos;
using Web.Server.Data.Requests;
using Web.Server.Data.Responses;

namespace Web.Server.Repositories.Interfaces
{
    public interface IHistoryRepository
    {
        Task AddRecordAsync(RecordRequest record);
        Task AddRecordsAsync(List<RecordRequest> record);
        Task<PaginatedRecordsResponse<RecordDto>> GetCardRecordsAsync(PaginatedRecordsRequest<int> param);
        Task<PaginatedRecordsResponse<RecordDto>> GetUserRecordsAsync(PaginatedRecordsRequest<string> param);
    }
}
