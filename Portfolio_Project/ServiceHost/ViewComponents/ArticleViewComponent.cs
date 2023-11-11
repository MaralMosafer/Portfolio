using _1_PortfolioQuery.Contracts.ArticleModel;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class ArticleViewComponent : ViewComponent
    {
        private readonly IArticleQuery _query;

        public ArticleViewComponent(IArticleQuery query)
        {
            _query = query;
        }
        public IViewComponentResult Invoke()
        {
            var article = _query.GetAll();
            return View(article);
        }
    }
}
