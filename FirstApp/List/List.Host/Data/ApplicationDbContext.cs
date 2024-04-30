using List.Host.Data.Entities;
using List.Host.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace TestCatalog.Host.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ListEntity> Lists { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ListEntityConfiguration());
        }
    }
}
