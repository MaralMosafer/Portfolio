using _1_PortfolioQuery.Contracts.PortfolioModel;

namespace _1_PortfolioQuery.Contracts.PortfolioCateoryModel
{
    public class CategoryQueryModel
    {
        public string Name { get; set; } = string.Empty;
        public List<PortfolioQueryModel> Portfolios { get; set; }
    }
}
