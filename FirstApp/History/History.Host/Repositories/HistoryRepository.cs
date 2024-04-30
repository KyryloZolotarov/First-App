using History.Host.Data.Entities;
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

        public async Task<List<RecordEntity>> GetRecordsAsync(string userId)
        {
            return await _dbContext.History.Where(c => c.UserId == userId).ToListAsync();
        }
    }
}
