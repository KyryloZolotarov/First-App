using ListCard.Data.Requests;
using ListCard.Data.Responses;

namespace ListCard.Repositories.Interfaces
{
    public interface IListRepository
    {
        Task AddListAsync(ListRequest list);
        Task PatchListAsync(int id, ListRequest list);
        Task DeleteListAsync(int id);
        Task<ListResponse> GetListAsync(int listId);
        Task<List<ListResponse>> GetListsAsync(string userId);
    }
}
