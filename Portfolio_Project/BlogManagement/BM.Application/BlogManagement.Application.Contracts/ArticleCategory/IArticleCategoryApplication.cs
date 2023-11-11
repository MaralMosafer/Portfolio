using _0_Framework.Application;

namespace BlogManagement.Application.Contracts.ArticleCategory
{
    public interface IArticleCategoryApplication
    {
        OperationResult Create(CreateArticleCategory command);
        OperationResult Edir(EditArticleCategory command);
        EditArticleCategory GetDetailsBy(long id);
        List<AtricleCategoryViewModel> GetAll();
    }
}