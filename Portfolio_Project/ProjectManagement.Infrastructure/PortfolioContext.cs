using Microsoft.EntityFrameworkCore;
using PortfolioManagement.Domain.InformationAgg;
using ProjectManagement.Infrastructure.Mappings;

namespace ProjectManagement.Infrastructure
{
    public class PortfolioContext : DbContext
    {
        public DbSet<Information> Information { get; set; }

        public PortfolioContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(InformationMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }
    }
}