using AccountManagement.Domain.AccountAgg;
using AccountManagement.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace AccountManagement.Infrastructure
{
    public class AccountContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public AccountContext(DbContextOptions<AccountContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(AccountMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }

    }
}