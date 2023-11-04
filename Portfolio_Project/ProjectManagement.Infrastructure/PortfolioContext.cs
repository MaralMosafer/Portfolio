using Microsoft.EntityFrameworkCore;
using PortfolioManagement.Domain.BiographyAgg;
using PortfolioManagement.Domain.EducationAgg;
using PortfolioManagement.Domain.InformationAgg;
using ProjectManagement.Infrastructure.Mappings;

namespace ProjectManagement.Infrastructure
{
    public class PortfolioContext : DbContext
    {
        public DbSet<Information> Information { get; set; }
        public DbSet<Biography> Biography { get; set; }
        public DbSet<Education> Education { get; set; }
        public PortfolioContext(DbContextOptions<PortfolioContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(InformationMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }
    }
}