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
        }
    }
}
