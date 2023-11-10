using _1_PortfolioQuery.Contracts.SkillModel;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class SkillViewComponent : ViewComponent
    {
        private readonly ISkillQuery _query;

        public SkillViewComponent(ISkillQuery query)
        {
            _query = query;
        }
        public IViewComponentResult Invoke()
        {
            var skill = _query.GetAll();
            return View(skill);
        }
    }
}
