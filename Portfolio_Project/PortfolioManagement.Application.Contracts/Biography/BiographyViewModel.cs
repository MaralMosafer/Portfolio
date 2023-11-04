namespace PortfolioManagement.Application.Contracts.Biography
{
    public class BiographyViewModel
    {
        public long Id { get; set; }
        public string Fullname { get; set; } = string.Empty;
        public string Birthday { get; set; } = string.Empty;
        public string Languages { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
