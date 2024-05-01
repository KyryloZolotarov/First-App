using ListCard.Data.Dtos;
using ListCard.Data.Requests;

namespace ListCard.Repositories.Interfaces
{
    public interface ICardRepository
    {
        Task<List<CardDto>> GetCardsAsync(int listId);
        Task<CardDto> GetCardAsync(int id);
        Task AddCardAsync(CardRequest card);
        Task DeleteCardAsync(int id);
        Task PatchCardAsync(int id, CardRequest card);
    }
}
