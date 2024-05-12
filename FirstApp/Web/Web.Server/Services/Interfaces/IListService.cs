using Microsoft.AspNetCore.JsonPatch;
using Web.Server.Data.Models;
using Web.Server.Data.Requests;

namespace Web.Server.Services.Interfaces
{
    public interface IListService
    {
        Task<int> AddListAsync(string userId, AddListRequest list);
        Task PatchListAsync(string userId, int id, JsonPatchDocument<UpdateListRequest> list);
        Task DeleteListAsync(string userId, DeleteListRequest list);
        Task<BoardListModel> GetListsAsync(int boardId);
    }
}
