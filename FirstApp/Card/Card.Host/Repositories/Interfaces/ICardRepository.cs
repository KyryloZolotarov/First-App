using Card.Host.Data.Entities;
using Card.Host.Models.Dtos;
using Card.Host.Models.Requests;

namespace Card.Host.Repositories.Interfaces
{
    public interface ICardRepository
    {
        Task<List<CardEntity>> GetCardsAsync(int listId);
        Task<CardEntity> GetCardAsync(int id);
        Task AddCardAsync(CardEntity card);
        Task DeleteCardAsync(CardEntity id);
        Task UpdateCardAsync(CardEntity card);
    }
}
