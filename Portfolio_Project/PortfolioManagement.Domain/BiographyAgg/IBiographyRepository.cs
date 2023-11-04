using _0_Framework.Domain;
using PortfolioManagement.Application.Contracts.Biography;

namespace PortfolioManagement.Domain.BiographyAgg
{
    public interface IBiographyRepository:IRepositoryBase<Biography>
    {
        EditBiography GetDetails(long id);
        BiographyViewModel GetItem();
    }
}
