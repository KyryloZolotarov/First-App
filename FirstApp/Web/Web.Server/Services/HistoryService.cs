using AutoMapper;
using Web.Server.Data.Models;
using Web.Server.Data.Requests;
using Web.Server.Data.Responses;
using Web.Server.Repositories.Interfaces;
using Web.Server.Services.Interfaces;

namespace Web.Server.Services
{
    public class HistoryService : IHistoryService
    {
        private readonly IHistoryRepository _historyRepository;
        private readonly IMapper _mapper;

        public HistoryService(IHistoryRepository historyRepository, IMapper mapper)
        {
            _historyRepository = historyRepository;
            _mapper = mapper;
        }

        public async Task<PaginatedRecordsResponse<RecordModel>> GetCardRecordsAsync(PaginatedRecordsRequest<int> param)
        {
            var records = await _historyRepository.GetCardRecordsAsync(param);
            var mappedRecords = new PaginatedRecordsResponse<RecordModel>()
            {
                PageIndex = records.PageIndex,
                PageSize = records.PageSize,
                Records = records.Records.Select(s => _mapper.Map<RecordModel>(s)).ToList()
            };
            return mappedRecords;
        }

        public async Task<PaginatedRecordsResponse<RecordModel>> GetUserRecordsAsync(PaginatedRecordsRequest<string> param)
        {
            var records = await _historyRepository.GetUserRecordsAsync(param);
            var mappedRecords = new PaginatedRecordsResponse<RecordModel>()
            {
                PageIndex = records.PageIndex,
                PageSize = records.PageSize,
                Records = records.Records.Select(s => _mapper.Map<RecordModel>(s)).ToList()
            };
            return mappedRecords;
        }
    }
}