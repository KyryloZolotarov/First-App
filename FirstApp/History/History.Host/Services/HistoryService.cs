using AutoMapper;
using History.Host.Data.Entities;
using History.Host.Models.Dtos;
using History.Host.Models.Requests;
using History.Host.Models.Responses;
using History.Host.Repositories.Interfaces;
using History.Host.Services.Interfaces;
using Infrastructure.Services;
using Infrastructure.Services.Interfaces;
using System.Collections.Generic;
using TestCatalog.Host.Data;

namespace History.Host.Services
{
    public class HistoryService : BaseDataService<ApplicationDbContext>, IHistoryService
    {
        private readonly IHistoryRepository _historyRepository;

        private readonly IMapper _mapper;

        public HistoryService(IHistoryRepository historyRepository, IMapper mapper, IDbContextWrapper<ApplicationDbContext> dbContextWrapper, ILogger<BaseDataService<ApplicationDbContext>> logger)
        : base(dbContextWrapper, logger)
        {
            _mapper = mapper;
            _historyRepository = historyRepository;
        }
        public async Task AddRecordAsync(RecordRequest record)
        {
            await ExecuteSafeAsync(async () =>
            {
                var recordToDb = _mapper.Map<RecordEntity>(record);
                await _historyRepository.AddRecordAsync(recordToDb);
            });
        }

        public async Task AddRecordsAsync(List<RecordRequest> records)
        {
            await ExecuteSafeAsync(async () =>
            {
                var recordToDb = records.Select(s => _mapper.Map<RecordEntity>(s)).ToList();
                await _historyRepository.AddRecordsAsync(recordToDb);
            });
        }

        public async Task<PaginatedRecordsResponse<RecordDto>> GetUserRecordsAsync(PaginatedRecordsRequest<string> param)
        {

            return await ExecuteSafeAsync(async () =>
            {
                var recordsList = await ExecuteSafeAsync(async () => await _historyRepository.GetUserRecordsAsync(param));
                var recordsResponse = new PaginatedRecordsResponse<RecordDto>() 
                { 
                    PageIndex = recordsList.PageIndex,
                    PageSize = recordsList.PageSize,
                    Records = recordsList.Records.Select(s => _mapper.Map<RecordDto>(s)).ToList() 
                };
                return (recordsResponse);
            });
        }

        public async Task<PaginatedRecordsResponse<RecordDto>> GetCardRecordsAsync(PaginatedRecordsRequest<int> param)
        {
            return await ExecuteSafeAsync(async () =>
            {
                var recordsList = await ExecuteSafeAsync(async () => await _historyRepository.GetCardRecordsAsync(param));
                var recordsResponse = new PaginatedRecordsResponse<RecordDto>()
                {
                    PageIndex = recordsList.PageIndex,
                    PageSize = recordsList.PageSize,
                    Records = recordsList.Records.Select(s => _mapper.Map<RecordDto>(s)).ToList()
                };
                return (recordsResponse);
            });
        }
    }
}
