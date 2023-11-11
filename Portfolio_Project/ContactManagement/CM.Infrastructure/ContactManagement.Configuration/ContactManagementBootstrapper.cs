using ContactManagement.Application;
using ContactManagement.Application.Contracts.Contact;
using ContactManagement.Domain.ContactAgg;
using ContactManagement.Infrastructure;
using ContactManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ContactManagement.Configuration
{
    public class ContactManagementBootstrapper
    {
        public static void Configure(IServiceCollection services, string ConnectionString)
        {
            services.AddDbContext<ContactContext>(options =>
            {
                options.UseSqlServer(ConnectionString);
            });
            services.AddTransient<IContactApplication, ContactApplication>();
            services.AddTransient<IContactRepository, ContactRepository>();
        }
    }
}