using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortfolioManagement.Domain.InformationAgg;

namespace ProjectManagement.Infrastructure.Mappings
{
    public class InformationMapping : IEntityTypeConfiguration<Information>
    {
        public void Configure(EntityTypeBuilder<Information> builder)
        {
            builder.ToTable("Information");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(80).IsRequired();
            builder.Property(x => x.Family).HasMaxLength(80).IsRequired();
            builder.Property(x => x.Biography).HasMaxLength(1000).IsRequired();
            builder.Property(x => x.Address).HasMaxLength(500).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(300).IsRequired();
            builder.Property(x => x.Picture).HasMaxLength(2000).IsRequired();
            builder.Property(x => x.PictureAlt).HasMaxLength(100).IsRequired();
            builder.Property(x => x.PictureTitle).HasMaxLength(100).IsRequired();
        }
    }
}