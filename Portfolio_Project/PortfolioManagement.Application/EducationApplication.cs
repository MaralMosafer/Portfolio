using _0_Framework.Application;
using PortfolioManagement.Application.Contracts.Education;
using PortfolioManagement.Domain.EducationAgg;

namespace PortfolioManagement.Application
{
    public class EducationApplication : IEducationApplication
    {
        private readonly IEducationRepository _educationRepository;

        public EducationApplication(IEducationRepository educationRepository)
        {
            _educationRepository = educationRepository;
        }

        public OperationResult Create(CreateEducation command)
        {
            var operationResult = new OperationResult();

            if (_educationRepository.Exists(x => x.University == command.University))
                return operationResult.Failed(ApplicationMessages.Duplicated);

            var education = new Education(command.University, command.Title, command.Description, command.StartDate, command.EndDate);
            _educationRepository.CreateAndSave(education);
            _educationRepository.SaveChanges();
            return operationResult.Successful();
        }

        public OperationResult Edit(EditEducation command)
        {
            var operationResult = new OperationResult();
            var education = _educationRepository.GetBy(command.Id);

            if (_educationRepository.Exists(x => x.University == command.University && x.Id != command.Id))
                return operationResult.Failed(ApplicationMessages.Duplicated);

            if (education == null)
                return operationResult.Failed(ApplicationMessages.NotFound);

            education.Edit(command.University, command.Title, command.Description, command.StartDate, command.EndDate);
            _educationRepository.SaveChanges();
            return operationResult.Successful();
        }

        public List<EducationViewModel> GetAll()
        {
            return _educationRepository.GetAll();
        }

        public EditEducation GetDetailsBy(long id)
        {
            return _educationRepository.GetDetailsBy(id);
        }
    }
}
