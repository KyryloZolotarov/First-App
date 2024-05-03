using Microsoft.AspNetCore.JsonPatch;
using Web.Server.Data.Models;
using Web.Server.Data.Requests;

namespace Web.Server.Services.Interfaces
{
    public interface ICardService
    {
        Task<CardModel> GetCardAsync(int id);
        Task AddCardAsync(string userId, AddCardRequest card);
        Task DeleteCardAsync(string userId, DeleteCardRequest card);
        Task PatchCardAsync(int id, string userId, JsonPatchDocument<UpdateCardRequest> card);
    }
}
