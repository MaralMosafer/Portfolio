using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortfolioManagement.Domain.ExperienceAgg;

namespace PortfolioManagement.Infrastructure.Mappings
{
    public class ExperienceMapping : IEntityTypeConfiguration<Experience>
    {
        public void Configure(EntityTypeBuilder<Experience> builder)
        {
            builder.ToTable("Experiences");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Place).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Title).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(200).IsRequired();
            builder.Property(x => x.StartDate).HasMaxLength(20).IsRequired();
            builder.Property(x => x.EndDate).HasMaxLength(20).IsRequired();
        }
    }
}
