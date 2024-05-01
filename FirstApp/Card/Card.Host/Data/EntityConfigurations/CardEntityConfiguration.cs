using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Card.Host.Data.Entities;

namespace Card.Host.Data.EntityConfigurations
{
    public class CardEntityConfiguration
    : IEntityTypeConfiguration<CardEntity>
    {
        public void Configure(EntityTypeBuilder<CardEntity> builder)
        {
            builder.ToTable("Cards");

            builder.HasKey(ci => ci.Id);
            builder.Property(cx => cx.Id).UseHiLo("card_hilo");

            builder.Property(ck => ck.Name)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(cz => cz.Description).HasMaxLength(300);

            builder.Property(cd => cd.Priority)
            .IsRequired()
            .HasConversion<string>();

            builder.Property(cx => cx.ListId).IsRequired();

            builder.Property(ca => ca.DueDate).IsRequired();
        }
    }
}
