namespace PortfolioManagement.Application.Contracts.Service
{
    public class ServiceViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public float Price { get; set; }
    }
}
