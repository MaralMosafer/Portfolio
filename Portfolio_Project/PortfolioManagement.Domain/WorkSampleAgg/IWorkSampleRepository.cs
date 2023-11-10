using _0_Framework.Domain;
using PortfolioManagement.Application.Contracts.WorkSample;

namespace PortfolioManagement.Domain.WorkSampleAgg
{
    public interface IWorkSampleRepository:IRepositoryBase<WorkSample> 
    {
        EditWorkSample GetDetailsBy(long id);
        List<WorkSampleViewModel> GetAll();
    }
}
