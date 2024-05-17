using Web.Server.Data.Models;
using Web.Server.Data.Requests;
using Web.Server.Data.Responses;

namespace Web.Server.Services.Interfaces
{
    public interface IHistoryService
    {
        Task<PaginatedRecordsResponse<RecordModel>> GetCardRecordsAsync(PaginatedRecordsRequest<int> param);
        Task<PaginatedRecordsResponse<RecordModel>> GetUserRecordsAsync(PaginatedRecordsRequest<string> param);
    }
}
