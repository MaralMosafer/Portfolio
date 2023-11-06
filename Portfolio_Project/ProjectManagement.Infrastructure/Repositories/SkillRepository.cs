using _0_Framework.Infrastructure;
using PortfolioManagement.Application.Contracts.Skill;
using PortfolioManagement.Domain.SkillAgg;
using ProjectManagement.Infrastructure;

namespace PortfolioManagement.Infrastructure.Repositories
{
    public class SkillRepository : RepositoryBase<Skill>, ISkillRepository
    {
        private readonly PortfolioContext _context;
        public SkillRepository(PortfolioContext context) : base(context)
        {
            _context = context;
        }

        public List<SkillViewModel> GetAll()
        {
            return _context.Skills.Select(s => new SkillViewModel
            {
                Id = s.Id,
                Name = s.Name,
                Value = s.Value
            }).ToList();
        }

        public EditSkill GetDetailsBy(long id)
        {
            return _context.Skills.Select(s => new EditSkill
            {
                Id = s.Id,
                Name = s.Name,
                Value = s.Value
            }).FirstOrDefault(s => s.Id == id);
        }
    }
}
