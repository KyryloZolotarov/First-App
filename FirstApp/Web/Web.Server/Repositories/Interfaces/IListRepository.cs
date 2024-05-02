using Web.Server.Data.Requests;

namespace Web.Server.Repositories.Interfaces
{
    public interface IListRepository
    {
        Task AddListAsync(ListRequest list);
        Task PatchListAsync(int id, ListRequest list);
        Task DeleteListAsync(int id);
        Task<UserListDto> GetListsAsync(string userId);
    }
}
