using BlogManagement.Application.Contracts.Article;
using BlogManagement.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Blog.Article
{
    public class CreateModel : PageModel
    {
        public CreateArticle Command;
        [TempData]
        public string Message { get; set; }
        private readonly IArticleApplication _articleApplication;
        private readonly IArticleCategoryApplication _categoryApplication;
        public SelectList Categories { get; set; }
        public CreateModel(IArticleApplication articleApplication, IArticleCategoryApplication categoryApplication)
        {
            _articleApplication = articleApplication;
            _categoryApplication = categoryApplication;
        }

        public void OnGet()
        {
            Categories = new SelectList(_categoryApplication.GetAll(), "Id", "Name");
        }
        public RedirectToPageResult OnPost(CreateArticle command)
        {
            var result = _articleApplication.Create(command);
            if (!result.IsSucceeded)
            {
                Message = result.Message;
                return RedirectToPage("./Create");
            }
            return RedirectToPage("./Index");


        }
    }
}
