using _0_Framework.Application;
using PortfolioManagement.Application.Contracts.Service;
using PortfolioManagement.Domain.ServiceAgg;
using PortfolioManagement.Domain.SkillAgg;

namespace PortfolioManagement.Application
{
    public class ServiceApplication : IServiceApplication
    {
        private readonly IServiceRepository _serviceRepository;

        public ServiceApplication(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public OperationResult Create(CreateService command)
        {
            var operationResult = new OperationResult();
            var service = new Service(command.Title, command.Description, command.Price);

            if (_serviceRepository.Exists(x => x.Title == command.Title))
                return operationResult.Failed(ApplicationMessages.Duplicated);

            _serviceRepository.CreateAndSave(service);
            _serviceRepository.SaveChanges();
            return operationResult.Successful();
        }

        public OperationResult Edit(EditService command)
        {
            var operationResult = new OperationResult();
            var service = _serviceRepository.GetBy(command.Id);

            if (_serviceRepository.Exists(x => x.Title == command.Title && x.Id != command.Id))
                return operationResult.Failed(ApplicationMessages.Duplicated);

            if (service == null)
                return operationResult.Failed(ApplicationMessages.NotFound);

            service.Edit(command.Title, command.Description, command.Price);
            _serviceRepository.SaveChanges();
            return operationResult.Successful();
        }

        public List<ServiceViewModel> GetAll()
        {
            return _serviceRepository.GetAll();
        }

        public EditService GetDetailsBy(long id)
        {
            return _serviceRepository.GetDetailsBy(id);
        }
    }
}
