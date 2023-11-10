using _1_PortfolioQuery.Contracts.ExperienceModel;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class ExperienceViewComponent : ViewComponent
    {
        private readonly IExperienceQuery _query;

        public ExperienceViewComponent(IExperienceQuery query)
        {
            _query = query;
        }
        public IViewComponentResult Invoke()
        {
            var experience = _query.GetAll();
            return View(experience);
        }
    }
}
