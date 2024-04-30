using History.Host.Data.Entities;
using History.Host.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace TestCatalog.Host.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<RecordEntity> History { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new RecordEntityConfiguration());
        }
    }
}
