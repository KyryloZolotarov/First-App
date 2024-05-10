using History.Host.Data.Entities;
using History.Host.Models.Requests;
using History.Host.Models.Responses;
using History.Host.Repositories.Interfaces;
using Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TestCatalog.Host.Data;

namespace History.Host.Repositories
{
    public class HistoryRepository : IHistoryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public HistoryRepository(IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
        {
            _dbContext = dbContextWrapper.DbContext;
        }

        public async Task AddRecordAsync(RecordEntity record)
        {
            await _dbContext.History.AddAsync(record);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddRecordsAsync(List<RecordEntity> records)
        {
            await _dbContext.History.AddRangeAsync(records);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<PaginatedRecordsResponse<RecordEntity>> GetUserRecordsAsync(PaginatedRecordsRequest<string> param)
        {
            IQueryable<RecordEntity> query = _dbContext.History;
            var count = await query.Where(c => c.UserId == param.Id).CountAsync();
            var result = await query.Where(c => c.UserId == param.Id)
                                    .Skip(param.PageSize * param.PageIndex)
                                    .Take(param.PageSize)
                                    .ToListAsync();

            return new PaginatedRecordsResponse<RecordEntity>()
            {
                PageSize = param.PageSize,
                PageIndex = param.PageIndex,
                TotalCount = count,
                Records = result
            };
        }

        
        public async Task<PaginatedRecordsResponse<RecordEntity>> GetCardRecordsAsync(PaginatedRecordsRequest<int> param)
        {
            IQueryable<RecordEntity> query = _dbContext.History;
            var count = await query.Where(c => c.CardId == param.Id).CountAsync();
            var result = await query.Where(c => c.CardId == param.Id).Skip(param.PageSize * param.PageIndex).Take(param.PageSize).ToListAsync();
            return new PaginatedRecordsResponse<RecordEntity>() { PageSize = param.PageSize, PageIndex = param.PageIndex, TotalCount = count, Records = result };
        }
    }
}
