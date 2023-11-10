using _0_Framework.Domain;

namespace PortfolioManagement.Domain.WorkSampleCategoryAgg
{
    public class WorkSampleCategory : DomainBase
    {
        public string Name { get; private set; } = string.Empty;

        public WorkSampleCategory(string name)
        {
            Name = name;
        }
    }
}
