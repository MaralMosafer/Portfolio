using _0_Framework.Domain;
using PortfolioManagement.Application.Contracts.Skill;

namespace PortfolioManagement.Domain.SkillAgg
{
    public interface ISkillRepository : IRepositoryBase<Skill>
    {
        EditSkill GetDetailsBy(long id);
        List<SkillViewModel> GetAll();
    }
}
