using List.Host.Models.Dtos;
using List.Host.Models.Requests;
using Microsoft.AspNetCore.JsonPatch;

namespace List.Host.Services.Interfaces
{
    public interface IListService
    {
        Task<int> AddListAsync(AddListRequest list);
        Task PatchListAsync(int listId, JsonPatchDocument<UpdateListRequest> list);
        Task DeleteListAsync(int listId);
        Task<List<ListDto>> GetListsAsync(string userId);
    }
}
