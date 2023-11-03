using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PortfolioManagement.Application.Contracts.Information;
using PortfolioManagement.Domain.InformationAgg;
using ProjectManagement.Infrastructure;

namespace ProjectManagement.Configuration
{
    public class PortfolioManagementBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<PortfolioContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddTransient<IInformationApplication, IInformationApplication>();
            services.AddTransient<IInformationRepository, IInformationRepository>();
        }
    }
}