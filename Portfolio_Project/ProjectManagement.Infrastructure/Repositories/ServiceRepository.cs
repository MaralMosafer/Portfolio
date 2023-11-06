using _0_Framework.Infrastructure;
using PortfolioManagement.Application.Contracts.Service;
using PortfolioManagement.Domain.ServiceAgg;
using ProjectManagement.Infrastructure;

namespace PortfolioManagement.Infrastructure.Repositories
{
    public class ServiceRepository : RepositoryBase<Service>, IServiceRepository
    {
        private readonly PortfolioContext _context;
        public ServiceRepository(PortfolioContext context) : base(context)
        {
            _context = context;
        }

        public List<ServiceViewModel> GetAll()
        {
            return _context.Services.Select(s => new ServiceViewModel
            {
                Id = s.Id,
                Title = s.Title,
                Description = s.Description,
                Price = s.Price,
            }).ToList();
        }

        public EditService GetDetailsBy(long id)
        {
            return _context.Services.Select(s => new EditService
            {
                Id = s.Id,
                Title = s.Title,
                Description = s.Description,
                Price = s.Price,
            }).FirstOrDefault(s => s.Id == id);
        }
    }
}
