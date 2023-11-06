using _0_Framework.Domain;
using PortfolioManagement.Application.Contracts.Experience;

namespace PortfolioManagement.Domain.ExperienceAgg
{
    public interface IExperienceRepository : IRepositoryBase<Experience>
    {
        EditExperience GetDetails(long id);
        List<ExperienceViewModel> GetAll();
    }
}
