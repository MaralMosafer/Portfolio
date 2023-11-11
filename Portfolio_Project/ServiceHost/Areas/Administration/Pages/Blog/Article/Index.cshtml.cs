using BlogManagement.Application.Contracts.Article;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Blog.Article
{
    public class IndexModel : PageModel
    {
        public List<ArticleViewModel> Articles { get; set; }
        public SelectList Categories { get; set; }
        private readonly IArticleApplication _articleApplication;

        public IndexModel(IArticleApplication articleApplication)
        {
            _articleApplication = articleApplication;
        }

        public void OnGet()
        {
            Articles = _articleApplication.GetAll();
        }
        public RedirectToPageResult OnGetRemove(long id)
        {
            _articleApplication.Remove(id);
            return RedirectToPage("./Index");
        }
        public RedirectToPageResult OnGetActive(long id)
        {
            _articleApplication.Active(id);
            return RedirectToPage("./Index");
        }
    }
}
