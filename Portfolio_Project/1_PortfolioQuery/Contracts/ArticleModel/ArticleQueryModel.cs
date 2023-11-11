namespace _1_PortfolioQuery.Contracts.ArticleModel
{
    public class ArticleQueryModel
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Picture { get; set; } = string.Empty;
        public string PictureAlt { get; set; } = string.Empty;
        public string PictureTitle { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string CreationDate { get; set; } = string.Empty;
    }
}
