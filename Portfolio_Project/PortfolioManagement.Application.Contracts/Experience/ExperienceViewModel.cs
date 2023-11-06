namespace PortfolioManagement.Application.Contracts.Experience
{
    public class ExperienceViewModel
    {
        public long Id { get; set; }
        public string Place { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string StartDate { get; set; } = string.Empty;
        public string EndDate { get; set; } = string.Empty;
    }
}
