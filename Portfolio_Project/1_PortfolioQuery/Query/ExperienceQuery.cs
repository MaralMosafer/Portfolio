using _1_PortfolioQuery.Contracts.ExperienceModel;
using ProjectManagement.Infrastructure;

namespace _1_PortfolioQuery.Query
{
    public class ExperienceQuery : IExperienceQuery
    {
        private readonly PortfolioContext _context;

        public ExperienceQuery(PortfolioContext context)
        {
            _context = context;
        }

        public List<ExperienceQueryModel> GetAll()
        {
            return _context.Experiences.Select(e => new ExperienceQueryModel
            {
                Description = e.Description,
                EndDate = e.EndDate,
                Place = e.Place,
                StartDate = e.StartDate,
                Title = e.Title,
            }).ToList();
        }
    }
}
