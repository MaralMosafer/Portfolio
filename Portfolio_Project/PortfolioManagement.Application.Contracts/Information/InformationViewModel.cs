using Microsoft.AspNetCore.Http;

namespace PortfolioManagement.Application.Contracts.Information
{
    public class InformationViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Family { get; set; } = string.Empty;
        public string Biography { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Picture { get; set; }
        public string PictureAlt { get; set; } = string.Empty;
        public string PictureTitle { get; set; } = string.Empty;
    }
}