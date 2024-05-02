using Web.Server.Data.Requests;

namespace Web.Server.Repositories.Interfaces
{
    public interface ICardRepository
    {
        Task<CardDto> GetCardAsync(int id);
        Task AddCardAsync(CardRequest card);
        Task DeleteCardAsync(int id);
        Task PatchCardAsync(int id, CardRequest card);
    }
}
