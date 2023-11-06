using _0_Framework.Domain;

namespace PortfolioManagement.Domain.ServiceAgg
{
    public class Service : DomainBase
    {
        public string Title { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public float Price { get; private set; }

        public Service(string title, string description, float price)
        {
            Title = title;
            Description = description;
            Price = price;
        }
        public void Edit(string title, string description, float price)
        {
            Title = title;
            Description = description;
            Price = price;
        }
    }
}
