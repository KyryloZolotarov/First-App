using Card.Host.Data.Entities;
using Card.Host.Models.Dtos;
using Card.Host.Models.Requests;

namespace Card.Host.Repositories.Interfaces
{
    public interface ICardRepository
    {
        Task<List<CardEntity>> GetCardsAsync(int listId);
        Task<CardEntity> GetCardAsync(int id);
        Task<int> AddCardAsync(CardEntity card);
        Task DeleteCardAsync(CardEntity id);
        Task DeleteCardsAsync(List<CardEntity> cards);
        Task UpdateCardAsync(CardEntity card);
    }
}
