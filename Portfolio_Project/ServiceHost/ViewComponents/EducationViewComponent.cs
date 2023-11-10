using _1_PortfolioQuery.Contracts.EducationModel;
using Microsoft.AspNetCore.Mvc;

namespace _1_PortfolioQuery.Query
{
    public class EducationViewComponent : ViewComponent
    {
        private readonly IEducationQuery _query;

        public EducationViewComponent(IEducationQuery query)
        {
            _query = query;
        }

        public IViewComponentResult Invoke()
        {
            var education = _query.GetAll();
            return View(education);
        }
    }
}
