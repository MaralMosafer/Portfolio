using _0_Framework.Infrastructure;
using BlogManagement.Application.Contracts.ArticleCategory;
using BlogManagement.Domain.ArticleCategoryAgg;
using Microsoft.EntityFrameworkCore;

namespace BlogManagement.Infrastructure.Repositories
{
    public class ArticleCategoryRepository : RepositoryBase<ArticleCategory>, IArticleCategoryRepository
    {
        private readonly BlogContext _context;
        public ArticleCategoryRepository(BlogContext context) : base(context)
        {
            _context = context;
        }

        public List<AtricleCategoryViewModel> GetAll()
        {
            return _context.ArticleCategories.Select(a => new AtricleCategoryViewModel
            {
                Id = a.Id,
                Name = a.Name,
            }).ToList();
        }

        public EditArticleCategory GetDetailsBy(long id)
        {
            return _context.ArticleCategories.Select(a => new EditArticleCategory
            {
                Id = a.Id,
                Name = a.Name,
            }).FirstOrDefault(a=>a.Id==id);
        }
    }
}
