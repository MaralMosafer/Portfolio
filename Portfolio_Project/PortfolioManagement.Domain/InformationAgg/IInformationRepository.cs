using _0_Framework.Domain;
using PortfolioManagement.Application.Contracts.Information;

namespace PortfolioManagement.Domain.InformationAgg
{
    public interface IInformationRepository : IRepositoryBase<Information>
    {
        EditInformation GetDetailsBy(long id);
        InformationViewModel GetItem();
    }
}