using History.Host.Data.Entities;
using History.Host.Models.Dtos;
using History.Host.Models.Requests;

namespace History.Host.Services.Interfaces
{
    public interface IHistoryService
    {
        Task<List<RecordDto>> GetRecordsAsync(string userId);
        Task AddRecordAsync(RecordRequest record);
    }
}
