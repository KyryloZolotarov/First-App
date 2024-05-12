using Microsoft.AspNetCore.JsonPatch;
using Web.Server.Data.Dtos;
using Web.Server.Data.Requests;

namespace Web.Server.Repositories.Interfaces
{
    public interface IBoardRepository
    {
        Task<int> AddBoardAsync(AddBoardRequest board);
        Task DeleteBoardAsync(int id);
        Task<IEnumerable<BoardDto>> GetBoardsAsync(string userId);
        Task PatchBoardAsync(int id, JsonPatchDocument<UpdateBoardRequest> board);
    }
}
