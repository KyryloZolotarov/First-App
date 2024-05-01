using ListCard.Data.Dtos;
using ListCard.Data.Requests;
using ListCard.Data.Responses;

namespace ListCard.Services.Interfaces
{
    public interface IListService
    {
        Task AddListAsync(ListRequest list);
        Task PatchListAsync(int id, ListRequest list);
        Task DeleteListAsync(int id);
        Task<ListDto> GetListAsync(int listId);
        Task<UserListDto> GetListsAsync(string userId);
    }
}
