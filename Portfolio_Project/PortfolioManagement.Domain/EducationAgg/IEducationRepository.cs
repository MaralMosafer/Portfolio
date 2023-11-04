using _0_Framework.Domain;
using PortfolioManagement.Application.Contracts.Education;

namespace PortfolioManagement.Domain.EducationAgg
{
    public interface IEducationRepository : IRepositoryBase<Education>
    {
        EditEducation GetDetailsBy(long id);
        List<EducationViewModel> GetAll();
    }
}
