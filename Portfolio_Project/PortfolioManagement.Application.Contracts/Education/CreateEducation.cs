namespace PortfolioManagement.Application.Contracts.Education
{
    public class CreateEducation
    {
        public string Title { get; set; } = string.Empty;
        public string University { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string StartDate { get; set; } = string.Empty;
        public string EdDate { get; set; } = string.Empty;
    }
}
