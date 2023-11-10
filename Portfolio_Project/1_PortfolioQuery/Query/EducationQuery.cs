using _1_PortfolioQuery.Contracts.EducationModel;
using ProjectManagement.Infrastructure;

namespace _1_PortfolioQuery.Query
{
    public class EducationQuery : IEducationQuery
    {
        private readonly PortfolioContext _context;

        public EducationQuery(PortfolioContext context)
        {
            _context = context;
        }

        public List<EducationQueryModel> GetAll()
        {
            return _context.Education.Select(e => new EducationQueryModel
            {
                Description = e.Description,
                EndDate = e.EndDate,
                StartDate = e.StartDate,
                Title = e.Title,
                University = e.University,
            }).ToList();
        }
    }
}
