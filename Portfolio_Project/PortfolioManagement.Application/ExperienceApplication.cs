using _0_Framework.Application;
using PortfolioManagement.Application.Contracts.Experience;
using PortfolioManagement.Domain.ExperienceAgg;

namespace PortfolioManagement.Application
{
    public class ExperienceApplication : IExperienceApplication
    {
        private readonly IExperienceRepository _experienceRepository;

        public ExperienceApplication(IExperienceRepository experienceRepository)
        {
            _experienceRepository = experienceRepository;
        }

        public OperationResult Create(CreateExperience command)
        {
            var operationResult = new OperationResult();
            var experience = new Experience(command.Place, command.Title, command.Description, command.StartDate, command.EndDate);

            if (_experienceRepository.Exists(x => x.Place == command.Place))
                return operationResult.Failed(ApplicationMessages.Duplicated);

            _experienceRepository.CreateAndSave(experience);
            _experienceRepository.SaveChanges();
            return operationResult.Successful();
        }

        public OperationResult Edit(EditExperience command)
        {
            var operationResult = new OperationResult();
            var experience = _experienceRepository.GetBy(command.Id);

            if (_experienceRepository.Exists(x => x.Place == command.Place && x.Id != command.Id))
                return operationResult.Failed(ApplicationMessages.Duplicated);

            if (experience == null)
                return operationResult.Failed(ApplicationMessages.NotFound);

            experience.Edit(command.Place, command.Title, command.Description, command.StartDate, command.EndDate);
            _experienceRepository.SaveChanges();
            return operationResult.Successful();
        }

        public List<ExperienceViewModel> GetAll()
        {
            return _experienceRepository.GetAll();
        }

        public EditExperience GetDetails(long id)
        {
            return _experienceRepository.GetDetails(id);
        }
    }
}
