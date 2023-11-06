using _0_Framework.Application;

namespace PortfolioManagement.Application.Contracts.Service
{
    public interface IServiceApplication
    {
        OperationResult Create(CreateService command);
        OperationResult Edit(EditService command);
        EditService GetDetailsBy(long id);
        List<ServiceViewModel> GetAll();
    }
}
