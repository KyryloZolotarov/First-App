using List.Host.Models.Dtos;
using List.Host.Models.Requests;

namespace List.Host.Services.Interfaces
{
    public interface IListService
    {
        Task AddListAsync(ListRequest list);
        Task UpdateListAsync(int listId, ListRequest list);
        Task DeleteListAsync(int listId);
        Task<ListDto> GetListAsync(int listId);
        Task<List<ListDto>> GetListsAsync(string userId);
    }
}
