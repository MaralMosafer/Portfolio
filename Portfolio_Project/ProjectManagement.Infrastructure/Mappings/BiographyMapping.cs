using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortfolioManagement.Domain.BiographyAgg;

namespace PortfolioManagement.Infrastructure.Mappings
{
    public class BiographyMapping : IEntityTypeConfiguration<Biography>
    {
        public void Configure(EntityTypeBuilder<Biography> builder)
        {
            builder.ToTable("Biography");
            builder.HasKey(x => x.Id);

            builder.Property(x=>x.Description).HasMaxLength(500).IsRequired();
            builder.Property(x=>x.Fullname).HasMaxLength(160).IsRequired();
            builder.Property(x=>x.Birthday).HasMaxLength(50).IsRequired();
            builder.Property(x=>x.Languages).HasMaxLength(80).IsRequired();
            builder.Property(x=>x.Nationality).HasMaxLength(50).IsRequired();
            builder.Property(x=>x.Address).HasMaxLength(80).IsRequired();
            builder.Property(x=>x.Mobile).HasMaxLength(20).IsRequired();
            builder.Property(x=>x.Email).HasMaxLength(50).IsRequired();
        }
    }
}
