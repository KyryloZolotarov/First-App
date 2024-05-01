using Web.Server.Data.Requests;

namespace Web.Server.Repositories.Interfaces
{
    public interface IListCardRepository
    {
        Task<List<CardDto>> GetCardsAsync(int listId);
        Task<CardDto> GetCardAsync(int id);
        Task AddCardAsync(CardRequest card);
        Task DeleteCardAsync(int id);
        Task PatchCardAsync(int id, CardRequest card);
        Task AddListAsync(ListRequest list);
        Task PatchListAsync(int id, ListRequest list);
        Task DeleteListAsync(int id);
        Task<UserListDto> GetListAsync(string userId);
    }
}
