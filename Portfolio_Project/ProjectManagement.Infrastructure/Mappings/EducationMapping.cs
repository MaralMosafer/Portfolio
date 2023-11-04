using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortfolioManagement.Domain.EducationAgg;

namespace PortfolioManagement.Infrastructure.Mappings
{
    public class EducationMapping : IEntityTypeConfiguration<Education>
    {
        public void Configure(EntityTypeBuilder<Education> builder)
        {
            builder.ToTable("Education");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.University).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Title).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(200).IsRequired();
            builder.Property(x => x.StartDate).HasMaxLength(20).IsRequired();
            builder.Property(x => x.EndDate).HasMaxLength(20).IsRequired();
        }
    }
}
