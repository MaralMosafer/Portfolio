using _0_Framework.Application;

namespace PortfolioManagement.Application.Contracts.WorkSample
{
    public interface IWorkSampleApplication
    {
        OperationResult Create(CreateWorkSample command);
        OperationResult Edit(EditWorkSample command);
        EditWorkSample GetDetailsBy(long id);
        List<WorkSampleViewModel> GetAll();
    }
}
