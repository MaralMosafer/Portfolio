using BlogManagement.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Blog.Category
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        public List<AtricleCategoryViewModel> articleCategories { get; set; }
        public IArticleCategoryApplication _articleCategoryApplication { get; set; }

        public IndexModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet()
        {
            articleCategories = _articleCategoryApplication.GetAll();
        }
        public RedirectToPageResult OnPostCreate(CreateArticleCategory command)
        {
            var result = _articleCategoryApplication.Create(command);
            if (!result.IsSucceeded)
                Message = result.Message;
            return RedirectToPage("./Index");
        }
        public RedirectToPageResult OnPostEdit(EditArticleCategory command)
        {
            _articleCategoryApplication.Edit(command);
            return RedirectToPage("./Index");
        }
        public PartialViewResult OnGetEdit(long id)
        {
            var ArticleCategory = _articleCategoryApplication.GetDetailsBy(id);
            return Partial("./Edit", ArticleCategory);
        }
    }
}
