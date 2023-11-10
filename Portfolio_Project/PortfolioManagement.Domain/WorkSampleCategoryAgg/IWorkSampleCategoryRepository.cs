using _0_Framework.Domain;
using PortfolioManagement.Application.Contracts.WorkSampleCategory;
using PortfolioManagement.Domain.WorkSampleCategoryAgg;

namespace PortfolioManagement.Domain.WorkSampleAgg
{
    public interface IWorkSampleCategoryRepository:IRepositoryBase<WorkSampleCategory>
    {
        EditWorkSampleCategory GetDetails(long id);
        List<WorkSampleCategoryViewModel> GetAll();
    }
}
