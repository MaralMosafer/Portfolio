using _0_Framework.Domain;
using BlogManagement.Domain.ArticleAgg;

namespace BlogManagement.Domain.ArticleCategoryAgg
{
    public class ArticleCategory : DomainBase
    {
        public string Name { get; set; } = string.Empty;
        public List<Article> Articles { get; set; }

        public ArticleCategory(string name)
        {
            Name = name;
            Articles = new List<Article>();
        }
        public void Edit(string name)
        {
            Name = name;
        }
    }
}