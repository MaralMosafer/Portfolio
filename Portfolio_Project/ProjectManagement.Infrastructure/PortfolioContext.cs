using Microsoft.EntityFrameworkCore;
using PortfolioManagement.Domain.BiographyAgg;
using PortfolioManagement.Domain.EducationAgg;
using PortfolioManagement.Domain.ExperienceAgg;
using PortfolioManagement.Domain.InformationAgg;
using PortfolioManagement.Domain.ServiceAgg;
using PortfolioManagement.Domain.SkillAgg;
using PortfolioManagement.Domain.WorkSampleAgg;
using PortfolioManagement.Domain.WorkSampleCategoryAgg;
using ProjectManagement.Infrastructure.Mappings;

namespace ProjectManagement.Infrastructure
{
    public class PortfolioContext : DbContext
    {
        public DbSet<Information> Information { get; set; }
        public DbSet<Biography> Biography { get; set; }
        public DbSet<Education> Education { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<WorkSampleCategory> WorkSampleCategories { get; set; }
        public DbSet<WorkSample> WorkSamples { get; set; }
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