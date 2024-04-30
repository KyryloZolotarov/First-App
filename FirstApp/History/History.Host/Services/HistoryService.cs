using AutoMapper;
using History.Host.Data.Entities;
using History.Host.Models.Dtos;
using History.Host.Models.Requests;
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

        public async Task<List<RecordDto>> GetRecordsAsync(string userId)
        {

            return await ExecuteSafeAsync(async () =>
            {
                var recordsList = await ExecuteSafeAsync(async () => await _historyRepository.GetRecordsAsync(userId));
                var recordsResponse = recordsList.Select(s => _mapper.Map<RecordDto>(s)).ToList();
                return (recordsResponse);
            });
        }
    }
}
