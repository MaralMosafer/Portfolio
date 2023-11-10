using _1_PortfolioQuery.Contracts.InformationModel;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
	public class CvHeaderViewComponent : ViewComponent
	{
		private readonly IInformationQuery _query;

		public CvHeaderViewComponent(IInformationQuery query)
		{
			_query = query;
		}

		public IViewComponentResult Invoke()
		{
			var information = _query.GetItem();
			return View(information);
		}
	}
}
