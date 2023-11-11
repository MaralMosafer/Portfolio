using _0_Framework.Application;
using AccountManagement.Application;
using AccountManagement.Application.Contracts.Account;
using AccountManagement.Domain.AccountAgg;
using AccountManagement.Infrastructure;
using AccountManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AccountManagement.Configuration
{
    public class AccountManagementBootstrapper
    {
        public static void Configure(IServiceCollection services, string ConnectionString)
        {
            services.AddDbContext<AccountContext>(options =>
            {
                options.UseSqlServer(ConnectionString);
            });

            services.AddTransient<IAccountApplication,AccountApplication>();
            services.AddTransient<IAccountRepository, AccountRepository>();

            services.AddSingleton<IPasswordHasher, PasswordHasher>();
            services.AddTransient<IAuthHelper, AuthHelper>();
        }
    }
}