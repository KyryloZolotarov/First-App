using Infrastructure.Services.Interfaces;
using List.Host.Data.Entities;
using List.Host.Models.Requests;
using List.Host.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TestCatalog.Host.Data;

namespace List.Host.Repositories
{
    public class ListRepository : IListRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ListRepository(IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
        {
            _dbContext = dbContextWrapper.DbContext;
        }

        public async Task<int> AddListAsync(ListEntity  list)
        {
            var listAdded = await _dbContext.Lists.AddAsync(list);
            await _dbContext.SaveChangesAsync();
            return listAdded.Entity.Id;
        }

        public async Task DeleteListAsync(ListEntity list)
        {
            _dbContext.Lists.Remove(list) ;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ListEntity> GetListAsync(int listId)
        {
            return await _dbContext.Lists.FirstOrDefaultAsync(h => h.Id == listId);
        }

        public async Task<List<ListEntity>> GetListsAsync(int boardId)
        {

            return await _dbContext.Lists.Where(c => c.BoardId == boardId).ToListAsync();
        }

        public async Task UpdateListAsync(ListEntity list)
        {
            _dbContext.Lists.Update(list);
            await _dbContext.SaveChangesAsync();
        }
    }
}
