using _0_Framework.Application;
using PortfolioManagement.Application.Contracts.Skill;
using PortfolioManagement.Domain.SkillAgg;

namespace PortfolioManagement.Application
{
    public class SkillApplication : ISkillApplication
    {
        private readonly ISkillRepository _skillRepository;

        public SkillApplication(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }

        public OperationResult Create(CreateSkill command)
        {
            var operationResult = new OperationResult();
            var skill = new Skill(command.Name, command.Value);

            if (_skillRepository.Exists(x => x.Name == command.Name))
                return operationResult.Failed(ApplicationMessages.Duplicated);

            _skillRepository.CreateAndSave(skill);
            _skillRepository.SaveChanges();
            return operationResult.Successful();
        }

        public OperationResult Edit(EditSkill command)
        {
            var operationResult = new OperationResult();
            var skill = _skillRepository.GetBy(command.Id);

            if (_skillRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operationResult.Failed(ApplicationMessages.Duplicated);

            if (skill == null)
                return operationResult.Failed(ApplicationMessages.NotFound);

            skill.Edit(command.Name, command.Value);
            _skillRepository.SaveChanges();
            return operationResult.Successful();
        }

        public List<SkillViewModel> GetAll()
        {
            return _skillRepository.GetAll();
        }

        public EditSkill GetDetailsBy(long id)
        {
            return _skillRepository.GetDetailsBy(id);
        }
    }
}
