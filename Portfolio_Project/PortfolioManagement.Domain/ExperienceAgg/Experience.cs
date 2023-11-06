using _0_Framework.Domain;

namespace PortfolioManagement.Domain.ExperienceAgg
{
    public class Experience : DomainBase
    {
        public string Place { get; private set; } = string.Empty;
        public string Title { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public string StartDate { get; private set; } = string.Empty;
        public string EndDate { get; private set; } = string.Empty;
        public Experience(string place, string title, string description, string startDate, string endDate)
        {
            Place = place;
            Title = title;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
        }
        public void Edit(string place, string title, string description, string startDate, string endDate)
        {
            Place = place;
            Title = title;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
