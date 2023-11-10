using _0_Framework.Application;

namespace PortfolioManagement.Application.Contracts.WorkSampleCategory
{
    public interface IWorkSampleCategoryApplication
    {
        OperationResult Create(CreateWorkSampleCategory command);
        OperationResult Edit(EditWorkSampleCategory command);
        EditWorkSampleCategory GetDetails(long id);
        List<WorkSampleCategoryViewModel> GetAll();
    }
}
