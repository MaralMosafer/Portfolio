using _0_Framework.Domain;
using BlogManagement.Application.Contracts.ArticleCategory;

namespace BlogManagement.Domain.ArticleCategoryAgg
{
    public interface IArticleCategoryRepository : IRepositoryBase<ArticleCategory>
    {
        EditArticleCategory GetDetailsBy(long id);
        List<AtricleCategoryViewModel> GetAll();
    }
}