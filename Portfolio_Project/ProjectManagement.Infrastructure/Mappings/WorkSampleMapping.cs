using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortfolioManagement.Domain.WorkSampleAgg;

namespace PortfolioManagement.Infrastructure.Mappings
{
    public class WorkSampleMapping : IEntityTypeConfiguration<WorkSample>
    {
        public void Configure(EntityTypeBuilder<WorkSample> builder)
        {
            builder.ToTable("WorkSamples");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Picture).HasMaxLength(2000).IsRequired();
            builder.Property(x => x.PictureAlt).HasMaxLength(150).IsRequired();
            builder.Property(x => x.PictureTitle).HasMaxLength(150).IsRequired();

            builder.HasOne(x => x.Category)
                .WithMany(x => x.WorkSamples)
                .HasForeignKey(x => x.CategoryId);
        }
    }
}
