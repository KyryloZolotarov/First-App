using Board.Host.Data.Entities;
using Board.Host.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Board.Host.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<BoardEntity> Boards { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new BoardEntityConfiguration());
        }
    }
}
