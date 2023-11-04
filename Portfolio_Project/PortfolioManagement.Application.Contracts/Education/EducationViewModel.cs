namespace PortfolioManagement.Application.Contracts.Education
{
    public class EducationViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string University { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string StartDate { get; set; } = string.Empty;
        public string EndDate { get; set; } = string.Empty;
    }
}
