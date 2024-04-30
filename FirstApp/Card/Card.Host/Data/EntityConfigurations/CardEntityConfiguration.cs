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
        }
    }
}
