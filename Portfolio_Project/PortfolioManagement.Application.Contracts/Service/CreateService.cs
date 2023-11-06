namespace PortfolioManagement.Application.Contracts.Service
{
    public class CreateService
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public float Price { get; set; }
    }
}
