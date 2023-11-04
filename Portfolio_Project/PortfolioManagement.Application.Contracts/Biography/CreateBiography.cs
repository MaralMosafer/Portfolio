namespace PortfolioManagement.Application.Contracts.Biography
{
    public class CreateBiography
    {
        public string Description { get; set; } = string.Empty;
        public string Fullname { get; set; } = string.Empty;
        public string Birthday { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Languages { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty;
        public string Adress { get; set; } = string.Empty;
        public string Mobile { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
