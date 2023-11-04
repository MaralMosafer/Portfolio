using _0_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using PortfolioManagement.Application.Contracts.Education;
using PortfolioManagement.Domain.EducationAgg;
using ProjectManagement.Infrastructure;

namespace PortfolioManagement.Infrastructure.Repositories
{
    public class EducationRepository : RepositoryBase<Education>, IEducationRepository
    {
        private readonly PortfolioContext _context;
        public EducationRepository(PortfolioContext context) : base(context)
        {
            _context = context;
        }

        public List<EducationViewModel> GetAll()
        {
            return _context.Education.Select(e => new EducationViewModel
            {
                Id = e.Id,
                Title = e.Title,
                EndDate = e.EndDate,
                StartDate = e.StartDate,
                University = e.University,
                Description = e.Description
            }).OrderByDescending(e => e.Id).ToList();
        }

        public EditEducation GetDetailsBy(long id)
        {
            return _context.Education.Select(e => new EditEducation
            {
                Id = e.Id,
                Title = e.Title,
                EndDate = e.EndDate,
                StartDate = e.StartDate,
                University = e.University,
                Description = e.Description
            }).FirstOrDefault(e => e.Id == id);
        }
    }
}
