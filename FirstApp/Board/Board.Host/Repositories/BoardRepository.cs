using Board.Host.Data;
using Board.Host.Data.Entities;
using Board.Host.Repositories.Interfaces;
using Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Board.Host.Repositories
{
    public class BoardRepository : IBoardRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public BoardRepository(IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
        {
            _dbContext = dbContextWrapper.DbContext;
        }

        public async Task<int> AddBoardAsync(BoardEntity board)
        {
            var boardAdded = await _dbContext.Boards.AddAsync(board);
            await _dbContext.SaveChangesAsync();
            return boardAdded.Entity.Id;
        }

        public async Task DeleteBoardAsync(BoardEntity board)
        {
            _dbContext.Boards.Remove(board);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<BoardEntity> GetBoardAsync(int boardId)
        {
            return await _dbContext.Boards.FirstOrDefaultAsync(h => h.Id == boardId);
        }

        public async Task<List<BoardEntity>> GetBoardsAsync(string userId)
        {

            return await _dbContext.Boards.Where(c => c.UserId == userId).ToListAsync();
        }

        public async Task UpdateBoardAsync(BoardEntity board)
        {
            _dbContext.Boards.Update(board);
            await _dbContext.SaveChangesAsync();
        }
    }
}
