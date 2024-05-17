using Card.Host.Data.Entities;
using Card.Host.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace TestCatalog.Host.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CardEntity> Cards { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CardEntityConfiguration());
        }
    }
}
