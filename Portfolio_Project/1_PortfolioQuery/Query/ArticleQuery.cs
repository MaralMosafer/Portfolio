using _1_PortfolioQuery.Contracts.ArticleModel;
using BlogManagement.Infrastructure;

namespace _1_PortfolioQuery.Query
{
    public class ArticleQuery : IArticleQuery
    {
        private readonly BlogContext _context;

        public ArticleQuery(BlogContext context)
        {
            _context = context;
        }

        public List<ArticleQueryModel> GetAll()
        {
            return _context.Articles.Where(x => x.IsActive).Select(x => new ArticleQueryModel
            {
                Id = x.Id,
                Category = x.Category.Name,
                Description = x.Description,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Title = x.Title,
                CreationDate = x.CreationDate.ToString("MMMM d, yyyy"),
            }).ToList();
        }
    }
}
