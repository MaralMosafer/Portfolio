using _0_Framework.Application;
using PortfolioManagement.Application.Contracts.Information;
using PortfolioManagement.Domain.InformationAgg;

namespace PortfolioManagement.Application
{
    public class InformationApplication : IInformationApplication
    {
        private readonly IInformationRepository _informationRepository;

        public InformationApplication(IInformationRepository informationRepository)
        {
            _informationRepository = informationRepository;
        }

        public OperationResult Create(CreateInformation command)
        {
            var operationResult = new OperationResult();

            if (_informationRepository.CheckDataExists() == false)
            {
                var information = new Information(command.Name, command.Family, command.Biography, command.Address, command.Email, command.Picture, command.PictureAlt, command.PictureTitle);
                _informationRepository.CreateAndSave(information);
                _informationRepository.SaveChanges();
            }
            return operationResult.Successful();
        }

        public OperationResult Edit(EditInformation command)
        {
            var operationResult = new OperationResult();

            if (_informationRepository.CheckDataExists() == true)
            {
                var information = _informationRepository.GetBy(command.Id);
                information.Edit(command.Name, command.Family, command.Biography, command.Address, command.Email, command.Picture, command.PictureAlt, command.PictureTitle);
                _informationRepository.SaveChanges();
            }
            return operationResult.Successful();
        }

        public EditInformation GetDetailsBy(long id)
        {
            return _informationRepository.GetDetailsBy(id);
        }

        public InformationViewModel GetItem()
        {
            return _informationRepository.GetItem();
        }
    }
}