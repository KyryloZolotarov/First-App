using ListCard.Data.Dtos;
using ListCard.Data.Requests;

namespace ListCard.Services.Interfaces
{
    public interface ICardService
    {
        Task<CardDto> GetCardAsync(int id);
        Task AddCardAsync(CardRequest card);
        Task DeleteCardAsync(int id);
        Task PatchCardAsync(int id, CardRequest card);
    }
}
