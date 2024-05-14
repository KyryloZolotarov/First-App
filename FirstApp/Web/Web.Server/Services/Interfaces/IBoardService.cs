using Microsoft.AspNetCore.JsonPatch;
using Web.Server.Data.Models;
using Web.Server.Data.Requests;

namespace Web.Server.Services.Interfaces
{
    public interface IBoardService
    {
        Task<int> AddBoardAsync(AddBoardRequest board);
        Task DeleteBoardAsync(string userId, DeleteBoardRequest board);
        Task<List<BoardModel>> GetBoardsAsync(string userId);
        Task PatchBoardAsync(string userId, int id, JsonPatchDocument<UpdateBoardRequest> board);

    }
}
