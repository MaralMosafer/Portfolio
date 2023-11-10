using _1_PortfolioQuery.Contracts.BiographyModel;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class BiographyViewComponent : ViewComponent
    {
        private readonly IBiographyQuery _query;

        public BiographyViewComponent(IBiographyQuery query)
        {
            _query = query;
        }

        public IViewComponentResult Invoke()
        {
            var biography = _query.GetItem();
            return View(biography);
        }
    }
}
