namespace _1_PortfolioQuery.Contracts.PortfolioCateoryModel
{
    public interface ICategoryQuery
    {
        List<CategoryQueryModel> GetCategoryWithPortfolios();
    }
}
