using _1_PortfolioQuery.Contracts.PortfolioModel;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class PortfolioViewComponent : ViewComponent
    {
        private readonly IPortfolioQuery _query;

        public PortfolioViewComponent(IPortfolioQuery query)
        {
            _query = query;
        }
        public IViewComponentResult Invoke()
        {
            var portfolio = _query.GetAll();
            return View(portfolio);
        }
    }
}
