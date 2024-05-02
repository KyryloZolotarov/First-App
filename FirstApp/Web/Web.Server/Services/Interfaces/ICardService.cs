using Microsoft.AspNetCore.JsonPatch;
using Web.Server.Data.Models;
using Web.Server.Data.Requests;

namespace Web.Server.Services.Interfaces
{
    public interface ICardService
    {
        Task<CardModel> GetCardAsync(int id);
        Task AddCardAsync(AddCardRequest card);
        Task DeleteCardAsync(int id);
        Task PatchCardAsync(int id, JsonPatchDocument<UpdateCardRequest> card);
    }
}
