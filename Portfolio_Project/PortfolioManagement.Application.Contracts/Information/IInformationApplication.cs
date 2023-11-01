using _0_Framework.Application;

namespace PortfolioManagement.Application.Contracts.Information
{
    public interface IInformationApplication
    {
        OperationResult Create(CreateInformation command);
        OperationResult Edit(EditInformation command);
        EditInformation GetDetailsBy(long id);
        InformationViewModel GetItem();
    }
}