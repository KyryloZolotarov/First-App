using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using List.Host.Data.Entities;

namespace List.Host.Data.EntityConfigurations
{
    public class ListEntityConfiguration
    : IEntityTypeConfiguration<ListEntity>
    {
        public void Configure(EntityTypeBuilder<ListEntity> builder)
        {
            builder.ToTable("Lists");

            builder.HasKey(ci => ci.Id);
            builder.Property(cx => cx.Id).UseHiLo("list_hilo");
            builder.Property(ck => ck.BoardId).IsRequired();
            builder.Property(cz => cz.Title).HasMaxLength(30);
        }
    }
}
