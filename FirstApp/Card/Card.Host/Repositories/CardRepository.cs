using Card.Host.Data.Entities;
using Card.Host.Repositories.Interfaces;
using Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using TestCatalog.Host.Data;

namespace Card.Host.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CardRepository(IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
        {
            _dbContext = dbContextWrapper.DbContext;
        }

        public async Task AddCardAsync(CardEntity card)
        {
            await _dbContext.Cards.AddAsync(card);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteCardAsync(CardEntity card)
        {
            _dbContext.Cards.Remove(card);
            await _dbContext.SaveChangesAsync();
        }
        public async Task DeleteCardsAsync(List<CardEntity> cards)
        {
            _dbContext.Cards.RemoveRange(cards);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<CardEntity> GetCardAsync(int id)
        {
            return await _dbContext.Cards.FirstOrDefaultAsync(h => h.Id == id);
        }

        public async Task<List<CardEntity>> GetCardsAsync(int listId)
        {
            return await _dbContext.Cards.Where(c => c.Id == listId).ToListAsync();
        }

        public async Task UpdateCardAsync(CardEntity card)
        {
            _dbContext.Cards.Update(card);
            await _dbContext.SaveChangesAsync();
        }
    }
}
