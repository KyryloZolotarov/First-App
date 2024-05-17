using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using History.Host.Data.Entities;

namespace History.Host.Data.EntityConfigurations
{
    public class RecordEntityConfiguration
    : IEntityTypeConfiguration<RecordEntity>
    {
        public void Configure(EntityTypeBuilder<RecordEntity> builder)
        {
            builder.ToTable("History");

            builder.HasKey(ci => ci.Id);

            builder.Property(cx => cx.Id).UseHiLo("record_hilo");

            builder.Property(cd => cd.Event)
                .IsRequired()
                .HasConversion<string>();

            builder.Property(cd => cd.Property)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(cd => cd.Origin).HasMaxLength(30);

            builder.Property(cd => cd.Destination).HasMaxLength(30);

            builder.Property(cd => cd.CardId).IsRequired();

            builder.Property(cd => cd.DateTime).IsRequired();

            builder.Property(ck => ck.UserId).IsRequired();
        }
    }
}
