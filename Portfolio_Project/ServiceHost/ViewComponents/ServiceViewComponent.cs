using _1_PortfolioQuery.Contracts.ServiceModel;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class ServiceViewComponent : ViewComponent
    {
        private readonly IServiceQuery _query;

        public ServiceViewComponent(IServiceQuery query)
        {
            _query = query;
        }
        public IViewComponentResult Invoke()
        {
            var service = _query.GetAll();
            return View(service);
        }
    }
}
