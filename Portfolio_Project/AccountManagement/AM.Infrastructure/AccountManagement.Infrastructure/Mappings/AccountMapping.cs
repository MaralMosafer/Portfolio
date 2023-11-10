using AccountManagement.Domain.AccountAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountManagement.Infrastructure.Mappings
{
    public class AccountMapping : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Accounts");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Fullname).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Email).HasMaxLength(250).IsRequired();
            builder.Property(x => x.ProfilePicture).HasMaxLength(2000).IsRequired();
            builder.Property(x => x.Password).HasMaxLength(1000).IsRequired();
        }
    }
}
