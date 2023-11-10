using _1_PortfolioQuery.Contracts.ServiceModel;
using ProjectManagement.Infrastructure;

namespace _1_PortfolioQuery.Query
{
    public class ServiceQuery : IServiceQuery
    {
        private readonly PortfolioContext _context;

        public ServiceQuery(PortfolioContext context)
        {
            _context = context;
        }

        public List<ServiceQueryModel> GetAll()
        {
            return _context.Services.Select(s => new ServiceQueryModel
            {
                Title = s.Title,
                Price = s.Price,
                Description = s.Description,
            }).ToList();
        }
    }
}
