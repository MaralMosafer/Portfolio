using _1_PortfolioQuery.Contracts.PortfolioCateoryModel;
using _1_PortfolioQuery.Contracts.PortfolioModel;
using Microsoft.EntityFrameworkCore;
using PortfolioManagement.Domain.WorkSampleAgg;
using ProjectManagement.Infrastructure;

namespace _1_PortfolioQuery.Query
{
    public class PortfolioCategoryQuery : ICategoryQuery
    {
        private readonly PortfolioContext _context;

        public PortfolioCategoryQuery(PortfolioContext context)
        {
            _context = context;
        }

        public List<CategoryQueryModel> GetCategoryWithPortfolios()
        {
            return _context.WorkSampleCategories
                .Include(x => x.WorkSamples)
                .ThenInclude(x => x.Category)
                .Select(x => new CategoryQueryModel
                {
                    Name = x.Name,
                    Portfolios = MapPortfolio(x.WorkSamples),
                }).ToList();
        }

        private static List<PortfolioQueryModel> MapPortfolio(List<WorkSample> workSamples)
        {
            return workSamples.Select(x => new PortfolioQueryModel
            {
                Category = x.Category.Name,
                Name = x.Name,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle
            }).ToList();
        }
    }
}
