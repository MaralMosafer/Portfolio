using _1_PortfolioQuery.Contracts.PortfolioModel;
using ProjectManagement.Infrastructure;

namespace _1_PortfolioQuery.Query
{
    public class PortfolioQuery : IPortfolioQuery
    {
        private readonly PortfolioContext _context;

        public PortfolioQuery(PortfolioContext context)
        {
            _context = context;
        }

        public List<PortfolioQueryModel> GetAll()
        {
            return _context.WorkSamples.Select(w => new PortfolioQueryModel
            {
                Name = w.Name,
                Category = w.Category.Name,
                Picture = w.Picture,
                PictureAlt = w.PictureAlt,
                PictureTitle = w.PictureTitle,
            }).ToList();
        }
    }
}
