using _0_Framework.Application;

namespace PortfolioManagement.Application.Contracts.Experience
{
    public interface IExperienceApplication
    {
        OperationResult Create(CreateExperience command);
        OperationResult Edit(EditExperience command);
        EditExperience GetDetailsBy(long id);
        List<ExperienceViewModel> GetAll();
    }
}
