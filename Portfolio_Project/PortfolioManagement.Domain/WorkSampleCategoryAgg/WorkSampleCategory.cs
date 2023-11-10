using _0_Framework.Domain;
using PortfolioManagement.Domain.WorkSampleAgg;

namespace PortfolioManagement.Domain.WorkSampleCategoryAgg
{
    public class WorkSampleCategory : DomainBase
    {
        public string Name { get; private set; } = string.Empty;
        public List<WorkSample> WorkSamples { get; private set; }

        public WorkSampleCategory(string name)
        {
            Name = name;
            WorkSamples = new List<WorkSample>();
        }
        public void Edit(string name)
        {
            Name = name;
        }
    }
}
