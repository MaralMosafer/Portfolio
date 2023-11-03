using _0_Framework.Application;
using PortfolioManagement.Application.Contracts.Information;
using PortfolioManagement.Domain.InformationAgg;

namespace PortfolioManagement.Application
{
    public class InformationApplication : IInformationApplication
    {
        private readonly IInformationRepository _informationRepository;
        private readonly IFileUploader _fileUploader;

        public InformationApplication(IInformationRepository informationRepository, IFileUploader fileUploader)
        {
            _informationRepository = informationRepository;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateInformation command)
        {
            var operationResult = new OperationResult();

            if (_informationRepository.CheckDataExists() == false)
            {
                var file = _fileUploader.Upload(command.Picture,"Resume");
                var information = new Information(command.Name, command.Family, command.Biography, command.Address, command.Email, file, command.PictureAlt, command.PictureTitle);
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
                var file = _fileUploader.Upload(command.Picture, "Resume");
                var information = _informationRepository.GetBy(command.Id);
                information.Edit(command.Name, command.Family, command.Biography, command.Address, command.Email, file, command.PictureAlt, command.PictureTitle);
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