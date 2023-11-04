using _0_Framework.Application;

namespace PortfolioManagement.Application.Contracts.Education
{
    public interface IEducationApplication
    {
        OperationResult Create(CreateEducation command);
        OperationResult Edit(EditEducation command);
        EditEducation GetDetailsBy(long id);
        List<EducationViewModel> GetAll();
    }
}
