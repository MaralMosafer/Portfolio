namespace PortfolioManagement.Application.Contracts.Experience
{
    public class CreateExperience
    {
        public string Place { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string StartDate { get; set; } = string.Empty;
        public string EndDate { get; set; } = string.Empty;
    }
}
