using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortfolioManagement.Domain.ServiceAgg;

namespace PortfolioManagement.Infrastructure.Mappings
{
    public class ServiceMapping : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable("Services");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(300).IsRequired();
        }
    }
}
