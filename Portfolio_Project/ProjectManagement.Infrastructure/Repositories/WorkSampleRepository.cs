using _0_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using PortfolioManagement.Application.Contracts.WorkSample;
using PortfolioManagement.Domain.WorkSampleAgg;
using ProjectManagement.Infrastructure;

namespace PortfolioManagement.Infrastructure.Repositories
{
    public class WorkSampleRepository : RepositoryBase<WorkSample>, IWorkSampleRepository
    {
        private readonly PortfolioContext _context;
        public WorkSampleRepository(PortfolioContext context) : base(context)
        {
            _context = context;
        }

        public List<WorkSampleViewModel> GetAll()
        {
            return _context.WorkSamples.Include(w => w.Category).Select(w => new WorkSampleViewModel
            {
                Id = w.Id,
                Category = w.Category.Name,
                Name = w.Name,
                IsActive = w.IsActive,
                Picture = w.Picture,
            }).ToList();
        }

        public EditWorkSample GetDetailsBy(long id)
        {
            return _context.WorkSamples.Select(w => new EditWorkSample
            {
                Id = w.Id,
                Name = w.Name,
                PictureAlt = w.PictureAlt,
                PictureTitle = w.PictureTitle,
                CategoryId = w.CategoryId
            }).FirstOrDefault(w => w.Id == id);
        }
    }
}
