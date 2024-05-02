using Web.Server.Data.Models;
using Web.Server.Data.Requests;

namespace Web.Server.Services.Interfaces
{
    public interface IListService
    {
        Task AddListAsync(ListRequest list);
        Task PatchListAsync(int id, ListRequest list);
        Task DeleteListAsync(int id);
        Task<UserListModel> GetListsAsync(string userId);
    }
}
