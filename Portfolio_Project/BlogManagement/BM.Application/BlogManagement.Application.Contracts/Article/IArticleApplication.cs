using _0_Framework.Application;

namespace BlogManagement.Application.Contracts.Article
{
    public interface IArticleApplication
    {
        OperationResult Create(CreateArticle command);
        OperationResult Edit(EditArticle command);
        EditArticle GetDetailsBy(long id);
        List<ArticleViewModel> GetAll();
        void Remove(long id);
        void Active(long id);
    }
}
