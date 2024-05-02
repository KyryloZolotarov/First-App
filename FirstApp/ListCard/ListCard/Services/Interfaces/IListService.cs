using ListCard.Data.Dtos;
using ListCard.Data.Requests;
using ListCard.Data.Responses;
using Microsoft.AspNetCore.JsonPatch;

namespace ListCard.Services.Interfaces
{
    public interface IListService
    {
        Task AddListAsync(AddListRequest list);
        Task PatchListAsync(int id, JsonPatchDocument<UpdateListRequest> list);
        Task DeleteListAsync(int id);
        Task<UserListDto> GetListsAsync(string userId);
    }
}
