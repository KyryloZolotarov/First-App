using Board.Host.Data.Entities;

namespace Board.Host.Repositories.Interfaces
{
    public interface IBoardRepository
    {
        Task<int> AddBoardAsync(BoardEntity board);
        Task DeleteBoardAsync(BoardEntity board);
        Task<BoardEntity> GetBoardAsync(int boardId);
        Task<List<BoardEntity>> GetBoardsAsync(string userId);
        Task UpdateBoardAsync(BoardEntity board);
    }
}
