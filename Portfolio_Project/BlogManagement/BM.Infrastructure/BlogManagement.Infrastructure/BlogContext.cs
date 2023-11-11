using BlogManagement.Domain.ArticleCategoryAgg;
using BlogManagement.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace BlogManagement.Infrastructure
{
    public class BlogContext : DbContext
    {
        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        public BlogContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly=typeof(ArticleCategoryMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }
    }
}