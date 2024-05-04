using Card.Host.Models.Dtos;
using Card.Host.Models.Requests;
using Microsoft.AspNetCore.JsonPatch;

namespace Card.Host.Services.Interfaces
{
    public interface ICardService
    {
        Task<List<CardDto>> GetCardsAsync(int listId);
        Task<CardDto> GetCardAsync(int id);
        Task<int> AddCardAsync(AddCardRequest card);
        Task DeleteCardAsync(int id);
        Task DeleteCardsAsync(int id);
        Task PatchCardAsync(int id, JsonPatchDocument<UpdateCardRequest> card);
    }
}
