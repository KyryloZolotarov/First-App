using Microsoft.EntityFrameworkCore;
using User.Host.Data.Entities;
using User.Host.Data.EntityConfigurations;

namespace TestCatalog.Host.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<UserEntity> UserProfiles { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserEntityConfiguration());
        }
    }
}
