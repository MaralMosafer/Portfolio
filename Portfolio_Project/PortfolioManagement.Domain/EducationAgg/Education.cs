using _0_Framework.Domain;

namespace PortfolioManagement.Domain.EducationAgg
{
    public class Education : DomainBase
    {
        public string University { get; private set; } = string.Empty;
        public string Title { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public string StartDate { get; private set; } = string.Empty;
        public string EndDate { get; private set; } = string.Empty;

        public Education(string university, string title, string description, string startDate, string endDate)
        {
            University = university;
            Title = title;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
        }
        public void Edit(string university, string title, string description, string startDate, string endDate)
        {
            University = university;
            Title = title;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
