using BlogManagement.Application.Contracts.ArticleCategory;

namespace BlogManagement.Application.Contracts.Article
{
    public class EditArticle : CreateArticle
    {
        public long Id { get; set; }
        public List<AtricleCategoryViewModel> Categories { get; set; }
    }
}
