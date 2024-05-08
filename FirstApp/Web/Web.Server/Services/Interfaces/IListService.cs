using Microsoft.AspNetCore.JsonPatch;
using Web.Server.Data.Models;
using Web.Server.Data.Requests;

namespace Web.Server.Services.Interfaces
{
    public interface IListService
    {
        Task<int> AddListAsync(AddListRequest list);
        Task PatchListAsync(string userId, int id, JsonPatchDocument<UpdateListRequest> list);
        Task DeleteListAsync(DeleteListRequest list);
        Task<UserListModel> GetListsAsync(string userId);
    }
}
