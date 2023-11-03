using Microsoft.EntityFrameworkCore;
using PortfolioManagement.Domain.InformationAgg;
using ProjectManagement.Infrastructure.Mappings;
using System.Data;

namespace ProjectManagement.Infrastructure
{
    public class PortfolioContext : DbContext
    {
        public DbSet<Information> Information { get; set; }
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