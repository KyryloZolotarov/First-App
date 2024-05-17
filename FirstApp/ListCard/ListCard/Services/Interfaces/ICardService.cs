using ListCard.Data.Dtos;
using ListCard.Data.Requests;
using Microsoft.AspNetCore.JsonPatch;

namespace ListCard.Services.Interfaces
{
    public interface ICardService
    {
        Task<CardDto> GetCardAsync(int id);
        Task<int> AddCardAsync(AddCardRequest card);
        Task DeleteCardAsync(int id);
        Task PatchCardAsync(int id, JsonPatchDocument<UpdateCardRequest> card);
    }
}
