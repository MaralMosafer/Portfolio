using ContactManagement.Domain.ContactAgg;
using ContactManagement.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace ContactManagement.Infrastructure
{
    public class ContactContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public ContactContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(ContactMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }
    }
}