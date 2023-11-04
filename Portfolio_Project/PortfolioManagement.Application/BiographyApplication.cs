using _0_Framework.Application;
using PortfolioManagement.Application.Contracts.Biography;
using PortfolioManagement.Domain.BiographyAgg;

namespace PortfolioManagement.Application
{
    public class BiographyApplication : IBiographyApplication
    {
        private readonly IBiographyRepository _biographyRepository;

        public BiographyApplication(IBiographyRepository biographyRepository)
        {
            _biographyRepository = biographyRepository;
        }

        public OperationResult Create(CreateBiography command)
        {
            if (_biographyRepository.CheckDataExists() == false)
            {
                var biography = new Biography(command.Description, command.Fullname, command.Birthday, command.Age, command.Languages, command.Nationality, command.Adress, command.Mobile, command.Email);
                _biographyRepository.CreateAndSave(biography);
                _biographyRepository.SaveChanges();
            }
            var operationResult = new OperationResult();
            return operationResult.Successful();
        }

        public OperationResult Edit(EditBiography command)
        {
            if (_biographyRepository.CheckDataExists() == true)
            {
                var biography = _biographyRepository.GetBy(command.Id);
                biography.Edit(command.Description, command.Fullname, command.Birthday, command.Age, command.Languages, command.Nationality, command.Adress, command.Mobile, command.Email);
                _biographyRepository.SaveChanges();
            }
            var operationResult = new OperationResult();
            return operationResult.Successful();
        }

        public EditBiography GetDetails(long id)
        {
            return _biographyRepository.GetDetails(id);
        }

        public BiographyViewModel GetItem()
        {
            return _biographyRepository.GetItem();
        }
    }
}
