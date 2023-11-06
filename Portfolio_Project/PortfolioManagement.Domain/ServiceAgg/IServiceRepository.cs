using _0_Framework.Domain;
using PortfolioManagement.Application.Contracts.Service;

namespace PortfolioManagement.Domain.ServiceAgg
{
    public interface IServiceRepository : IRepositoryBase<Service>
    {
        EditService GetDetailsBy(long id);
        List<ServiceViewModel> GetAll();
    }
}
