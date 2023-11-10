using PortfolioManagement.Application.Contracts.WorkSampleCategory;

namespace PortfolioManagement.Application.Contracts.WorkSample
{
    public class EditWorkSample : CreateWorkSample
    {
        public long Id { get; set; }
        public List<WorkSampleCategoryViewModel> Categories { get; set; }
    }
}
