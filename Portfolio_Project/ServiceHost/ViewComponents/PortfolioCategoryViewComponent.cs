using _1_PortfolioQuery.Contracts.PortfolioCateoryModel;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class PortfolioCategoryViewComponent : ViewComponent
    {
        private readonly ICategoryQuery _query;

        public PortfolioCategoryViewComponent(ICategoryQuery query)
        {
            _query = query;
        }
        public IViewComponentResult Invoke()
        {
            var category = _query.GetCategoryWithPortfolios();
            return View(category);
        }
    }
}
