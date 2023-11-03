using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PortfolioManagement.Application;
using PortfolioManagement.Application.Contracts.Information;
using PortfolioManagement.Domain.InformationAgg;
using ProjectManagement.Infrastructure;
using ProjectManagement.Infrastructure.Repositories;

namespace ProjectManagement.Configuration
{
    public class PortfolioManagementBootstrapper
    {
        public static void Configure(IServiceCollection services, string ConnectionString)
        {
            services.AddDbContext<PortfolioContext>(options =>
            {
                options.UseSqlServer(ConnectionString);
            });
            services.AddTransient<IInformationApplication, InformationApplication>();
            services.AddTransient<IInformationRepository,  InformationRepository>();

        }
    }
}