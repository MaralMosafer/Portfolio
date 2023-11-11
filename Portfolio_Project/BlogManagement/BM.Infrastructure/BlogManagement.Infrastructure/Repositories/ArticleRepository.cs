using _0_Framework.Infrastructure;
using BlogManagement.Application.Contracts.Article;
using BlogManagement.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;

namespace BlogManagement.Infrastructure.Repositories
{
    public class ArticleRepository : RepositoryBase<Article>, IArticleRepository
    {
        private readonly BlogContext _context;
        public ArticleRepository(BlogContext context) : base(context)
        {
            _context = context;
        }

        public List<ArticleViewModel> GetAll()
        {
            return _context.Articles.Select(a => new ArticleViewModel
            {
                Id = a.Id,
                Category = a.Category.Name,
                CreationDate = a.CreationDate.ToString("MMMM d, yyyy"),
                Description = a.Description,
                IsActive = a.IsActive,
                Picture = a.Picture,
                Title = a.Title
            }).ToList();
        }

        public EditArticle GetDetailsBy(long id)
        {
            return _context.Articles.Select(a => new EditArticle
            {
                Id = a.Id,
                Description = a.Description,
                Title = a.Title,
                CategoryId = a.CategoryId,
                PictureAlt = a.PictureAlt,
                PictureTitle = a.PictureTitle,
            }).FirstOrDefault(a => a.Id == id);
        }
    }
}
