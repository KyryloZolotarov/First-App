using List.Host.Data.Entities;
using List.Host.Models.Requests;

namespace List.Host.Repositories.Interfaces
{
    public interface IListRepository
    {
        Task<int> AddListAsync(ListEntity list);
        Task UpdateListAsync(ListEntity list);
        Task DeleteListAsync(ListEntity list);
        Task<ListEntity> GetListAsync(int listId);
        Task<List<ListEntity>> GetListsAsync(string userId);
    }
}
