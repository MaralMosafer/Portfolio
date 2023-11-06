using _0_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using PortfolioManagement.Application.Contracts.Experience;
using PortfolioManagement.Domain.ExperienceAgg;
using ProjectManagement.Infrastructure;

namespace PortfolioManagement.Infrastructure.Repositories
{
    public class ExperienceRepository : RepositoryBase<Experience>, IExperienceRepository
    {
        private readonly PortfolioContext _context;
        public ExperienceRepository(PortfolioContext context) : base(context)
        {
            _context = context;
        }

        public List<ExperienceViewModel> GetAll()
        {
            return _context.Experiences.Select(e => new ExperienceViewModel
            {
                Id = e.Id,
                Place = e.Place,
                Title = e.Title,
                Description = e.Description,
                EndDate = e.EndDate,
                StartDate = e.StartDate,
            }).ToList();
        }

        public EditExperience GetDetails(long id)
        {
            return _context.Experiences.Select(e => new EditExperience
            {
                Id = e.Id,
                Place = e.Place,
                Title = e.Title,
                Description = e.Description,
                EndDate = e.EndDate,
                StartDate = e.StartDate,
            }).FirstOrDefault(e => e.Id == id);
        }
    }
}
