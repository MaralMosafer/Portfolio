namespace PortfolioManagement.Application.Contracts.WorkSample
{
    public class WorkSampleViewModel
    {
        public long Id { get; set; }
        public string Picture { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
