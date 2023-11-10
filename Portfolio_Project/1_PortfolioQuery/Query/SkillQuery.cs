using _1_PortfolioQuery.Contracts.SkillModel;
using ProjectManagement.Infrastructure;

namespace _1_PortfolioQuery.Query
{
    public class SkillQuery : ISkillQuery
    {
        private readonly PortfolioContext _context;

        public SkillQuery(PortfolioContext context)
        {
            _context = context;
        }

        public List<SkillQueryModel> GetAll()
        {
            return _context.Skills.Select(s => new SkillQueryModel
            {
                Name = s.Name,
                Value = s.Value,
            }).ToList();
        }
    }
}
