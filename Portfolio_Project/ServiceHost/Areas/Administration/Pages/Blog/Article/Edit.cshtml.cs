using BlogManagement.Application.Contracts.Article;
using BlogManagement.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Blog.Article
{
    public class EditModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        public EditArticle Article { get; set; }
        private readonly IArticleApplication _articleApplication;
        private readonly IArticleCategoryApplication _articleCategoryApplication;
        public SelectList Categories { get; set; }

        public EditModel(IArticleCategoryApplication articleCategoryApplication, IArticleApplication articleApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
            _articleApplication = articleApplication;
        }

        public void OnGet(long id)
        {
            Article = _articleApplication.GetDetailsBy(id);
            Categories = new SelectList(_articleCategoryApplication.GetAll(), "Id", "Name");
        }
        public RedirectToPageResult OnPost(EditArticle command)
        {
            var result = _articleApplication.Edit(command);
            if (!result.IsSucceeded)
            {
                Message = result.Message;
                return RedirectToPage("./Edit");
            }
            return RedirectToPage("./Index");
        }
    }
}
