using Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using TestCatalog.Host.Data;
using User.Host.Data.Entities;
using User.Host.Repositories.Interfaces;

namespace User.Host.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
        {
            _dbContext = dbContextWrapper.DbContext;
        }

        public async Task<UserEntity> AddUserAsync(UserEntity user)
        {
            var result = await _dbContext.UserProfiles.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteUserAsync(UserEntity user)
        {
            _dbContext.UserProfiles.Remove(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<UserEntity> GetUserAsync(string userId)
        {
            return await _dbContext.UserProfiles.FirstOrDefaultAsync(h => h.Id == userId);
        }

        public async Task<UserEntity> GetUserByEmailAsync(string email)
        {
            return await _dbContext.UserProfiles.FirstOrDefaultAsync(h => h.Email == email);
        }

        public async Task UpdateUserAsync(UserEntity user)
        {
            _dbContext.UserProfiles.Update(user);
            await _dbContext.SaveChangesAsync();
        }
    }
}
