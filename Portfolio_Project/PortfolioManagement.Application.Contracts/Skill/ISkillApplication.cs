using _0_Framework.Application;

namespace PortfolioManagement.Application.Contracts.Skill
{
    public interface ISkillApplication
    {
        OperationResult Create(CreateSkill command);
        OperationResult Edit(EditSkill command);
        EditSkill GetDetailsBy(long id);
        List<SkillViewModel> GetAll();
    }
}
