using Microsoft.AspNetCore.JsonPatch;
using Web.Server.Data.Requests;

namespace Web.Server.Repositories.Interfaces
{
    public interface IListRepository
    {
        Task<int> AddListAsync(AddListRequest list);
        Task PatchListAsync(int id, JsonPatchDocument<UpdateListRequest> list);
        Task DeleteListAsync(int id);
        Task<UserListDto> GetListsAsync(string userId);
    }
}
