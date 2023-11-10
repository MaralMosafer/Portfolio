using _0_Framework.Application;
using PortfolioManagement.Application.Contracts.WorkSampleCategory;
using PortfolioManagement.Domain.WorkSampleAgg;
using PortfolioManagement.Domain.WorkSampleCategoryAgg;

namespace PortfolioManagement.Application
{
    public class WorkSampleCategoryApplication : IWorkSampleCategoryApplication
    {
        private readonly IWorkSampleCategoryRepository _repository;

        public WorkSampleCategoryApplication(IWorkSampleCategoryRepository workSampleCategoryRepository)
        {
            _repository = workSampleCategoryRepository;
        }

        public OperationResult Create(CreateWorkSampleCategory command)
        {
            var operationResult = new OperationResult();

            if (_repository.Exists(x => x.Name == command.Name))
                return operationResult.Failed(ApplicationMessages.Duplicated);

            var category = new WorkSampleCategory(command.Name);
            _repository.CreateAndSave(category);
            _repository.SaveChanges();
            return operationResult.Successful();
        }

        public OperationResult Edit(EditWorkSampleCategory command)
        {
            var operationResult = new OperationResult();
            var category = _repository.GetBy(command.Id);

            if (_repository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operationResult.Failed(ApplicationMessages.Duplicated);

            if (category == null)
                return operationResult.Failed(ApplicationMessages.NotFound);

            category.Edit(command.Name);
            _repository.SaveChanges();
            return operationResult.Successful();
        }

        public List<WorkSampleCategoryViewModel> GetAll()
        {
            return _repository.GetAll();
        }

        public EditWorkSampleCategory GetDetails(long id)
        {
            return _repository.GetDetails(id);
        }
    }
}
