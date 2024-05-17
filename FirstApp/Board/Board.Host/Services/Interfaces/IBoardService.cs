using Board.Host.Models.Dtos;
using Board.Host.Models.Requests;
using Microsoft.AspNetCore.JsonPatch;

namespace Board.Host.Services.Interfaces
{
    public interface IBoardService
    {
        Task<int> AddBoardAsync(AddBoardRequest board);
        Task DeleteBoardAsync(int boardId);
        Task<List<BoardDto>> GetBoardsAsync(string userId);
        Task PatchBoardAsync(int boardId, JsonPatchDocument<UpdateBoardRequest> board);
    }
}
