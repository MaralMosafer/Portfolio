using _0_Framework.Domain;
using BlogManagement.Application.Contracts.Article;

namespace BlogManagement.Domain.ArticleAgg
{
    public interface IArticleRepository : IRepositoryBase<Article>
    {
        EditArticle GetDetailsBy(long id);
        List<ArticleViewModel> GetAll();
    }
}
