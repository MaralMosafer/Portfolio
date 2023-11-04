using _0_Framework.Application;

namespace PortfolioManagement.Application.Contracts.Biography
{
    public interface IBiographyApplication
    {
        OperationResult Create(CreateBiography command);
        OperationResult Edit(EditBiography command);
        EditBiography GetDetails(long id);
        BiographyViewModel GetItem();
    }
}
