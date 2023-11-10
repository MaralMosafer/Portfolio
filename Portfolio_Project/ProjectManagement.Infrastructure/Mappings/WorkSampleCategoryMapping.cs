using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortfolioManagement.Domain.WorkSampleCategoryAgg;

namespace PortfolioManagement.Infrastructure.Mappings
{
    public class WorkSampleCategoryMapping : IEntityTypeConfiguration<WorkSampleCategory>
    {
        public void Configure(EntityTypeBuilder<WorkSampleCategory> builder)
        {
            builder.ToTable("WorkSampleCategories");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();

            //will Add Relation
        }
    }
}
