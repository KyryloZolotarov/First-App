using Microsoft.AspNetCore.JsonPatch;
using Web.Server.Data.Requests;

namespace Web.Server.Repositories.Interfaces
{
    public interface ICardRepository
    {
        Task<CardDto> GetCardAsync(int id);
        Task AddCardAsync(AddCardRequest card);
        Task DeleteCardAsync(int id);
        Task PatchCardAsync(int id, JsonPatchDocument<UpdateCardRequest> card);
    }
}
