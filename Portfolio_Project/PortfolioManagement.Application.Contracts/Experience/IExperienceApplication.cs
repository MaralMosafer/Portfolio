using _0_Framework.Application;

namespace PortfolioManagement.Application.Contracts.Experience
{
    public interface IExperienceApplication
    {
        OperationResult Create(CreateExperience command);
        OperationResult Edit(EditExperience command);
        EditExperience GetDetails(long id);
        List<ExperienceViewModel> GetAll();
    }
}
