using _0_Framework.Domain;

namespace PortfolioManagement.Domain.InformationAgg
{
    public class Information : DomainBase
    {
        public string Name { get; set; } = string.Empty;
        public string Family { get; set; } = string.Empty;
        public string Biography { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Picture { get; set; } = string.Empty;
        public string PictureAlt { get; set; } = string.Empty;
        public string PictureTitle { get; set; } = string.Empty;
    }
}