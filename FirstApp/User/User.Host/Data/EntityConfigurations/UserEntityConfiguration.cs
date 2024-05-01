using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using User.Host.Data.Entities;

namespace User.Host.Data.EntityConfigurations
{
    public class UserEntityConfiguration
    : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
                .IsRequired();

            builder.Property(ci => ci.FirstName)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(cb => cb.LastName)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(cd => cd.Email)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(cg => cg.Password)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
