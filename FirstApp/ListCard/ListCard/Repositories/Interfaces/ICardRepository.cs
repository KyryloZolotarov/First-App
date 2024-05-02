using ListCard.Data.Dtos;
using ListCard.Data.Requests;
using Microsoft.AspNetCore.JsonPatch;

namespace ListCard.Repositories.Interfaces
{
    public interface ICardRepository
    {
        Task<List<CardDto>> GetCardsAsync(int listId);
        Task<CardDto> GetCardAsync(int id);
        Task AddCardAsync(AddCardRequest card);
        Task DeleteCardAsync(int id);
        Task PatchCardAsync(int id, JsonPatchDocument<UpdateCardRequest> card);
        Task DeleteCardsByListAsync(int id);
    }
}
