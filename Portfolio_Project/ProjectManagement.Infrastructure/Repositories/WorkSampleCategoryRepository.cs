using _0_Framework.Infrastructure;
using PortfolioManagement.Application.Contracts.WorkSampleCategory;
using PortfolioManagement.Domain.WorkSampleAgg;
using PortfolioManagement.Domain.WorkSampleCategoryAgg;
using ProjectManagement.Infrastructure;

namespace PortfolioManagement.Infrastructure.Repositories
{
    public class WorkSampleCategoryRepository : RepositoryBase<WorkSampleCategory>, IWorkSampleCategoryRepository
    {
        private readonly PortfolioContext _context;
        public WorkSampleCategoryRepository(PortfolioContext context) : base(context)
        {
            _context = context;
        }

        public List<WorkSampleCategoryViewModel> GetAll()
        {
            return _context.WorkSampleCategories.Select(w => new WorkSampleCategoryViewModel
            {
                Id = w.Id,
                Name = w.Name,
            }).ToList();
        }

        public EditWorkSampleCategory GetDetails(long id)
        {
            return _context.WorkSampleCategories.Select(w => new EditWorkSampleCategory
            {
                Id = w.Id,
                Name = w.Name,
            }).FirstOrDefault(w => w.Id == id);
        }
    }
}
