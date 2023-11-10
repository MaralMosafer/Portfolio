using _0_Framework.Application;
using PortfolioManagement.Application.Contracts.WorkSample;
using PortfolioManagement.Domain.WorkSampleAgg;

namespace PortfolioManagement.Application
{
    public class WorkSampleApplication : IWorkSampleApplication
    {
        private readonly IWorkSampleRepository _workSampleRepository;
        private readonly IFileUploader _fileUploader;
        public WorkSampleApplication(IWorkSampleRepository workSampleRepository, IFileUploader fileUploader)
        {
            _workSampleRepository = workSampleRepository;
            _fileUploader = fileUploader;
        }

        public void Active(long id)
        {
            var sample = _workSampleRepository.GetBy(id);
            sample.Active();
            _workSampleRepository.SaveChanges();
        }

        public OperationResult Create(CreateWorkSample command)
        {
            var operationResult = new OperationResult();

            if (_workSampleRepository.Exists(x => x.Name == command.Name))
                return operationResult.Failed(ApplicationMessages.Duplicated);

            var file = _fileUploader.Upload(command.Picture, "Portfolio");
            var portfolio = new WorkSample(command.Name, file, command.PictureAlt, command.PictureTitle, command.CategoryId);
            _workSampleRepository.CreateAndSave(portfolio);
            _workSampleRepository.SaveChanges();
            return operationResult.Successful();
        }

        public OperationResult Edit(EditWorkSample command)
        {
            var operationResult = new OperationResult();
            var portfolio = _workSampleRepository.GetBy(command.Id);

            if (_workSampleRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operationResult.Failed(ApplicationMessages.Duplicated);
            if (portfolio == null)
                return operationResult.Failed(ApplicationMessages.NotFound);

            var file = _fileUploader.Upload(command.Picture, "Portfolio");
            portfolio.Edit(command.Name, file, command.PictureAlt, command.PictureTitle, command.CategoryId);
            _workSampleRepository.SaveChanges();
            return operationResult.Successful();
        }

        public List<WorkSampleViewModel> GetAll()
        {
            return _workSampleRepository.GetAll();
        }

        public EditWorkSample GetDetailsBy(long id)
        {
            return _workSampleRepository.GetDetailsBy(id);
        }

        public void Remove(long id)
        {
            var sample = _workSampleRepository.GetBy(id);
            sample.Remove();
            _workSampleRepository.SaveChanges();
        }
    }
}
