using _0_Framework.Domain;

namespace BlogManagement.Domain.ArticleCategoryAgg
{
    public class ArticleCategory:DomainBase
    {
        public string Name { get; set; } = string.Empty;

        public ArticleCategory(string name)
        {
            Name = name;
        }
        public void Edit(string name)
        {
            Name = name;
        }
    }
}