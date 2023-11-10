using Microsoft.AspNetCore.Http;

namespace PortfolioManagement.Application.Contracts.WorkSample
{
    public class CreateWorkSample
    {
        public string Name { get; set; } = string.Empty;
        public IFormFile Picture { get; set; }
        public string PictureTitle { get; set; } = string.Empty;
        public string PictureAlt { get; set; } = string.Empty;
        public long CategoryId { get; set; }
    }
}
