using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Board.Host.Data.Entities;

namespace Board.Host.Data.EntityConfigurations
{
    public class BoardEntityConfiguration
    : IEntityTypeConfiguration<BoardEntity>
    {
        public void Configure(EntityTypeBuilder<BoardEntity> builder)
        {
            builder.ToTable("Boards");

            builder.HasKey(ci => ci.Id);
            builder.Property(cx => cx.Id).UseHiLo("board_hilo");
            builder.Property(ck => ck.UserId).IsRequired();
            builder.Property(cz => cz.Title).HasMaxLength(30);
        }
    }
}
