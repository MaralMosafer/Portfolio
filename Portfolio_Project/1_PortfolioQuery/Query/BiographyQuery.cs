using _1_PortfolioQuery.Contracts.BiographyModel;
using ProjectManagement.Infrastructure;

namespace _1_PortfolioQuery.Query
{
    public class BiographyQuery : IBiographyQuery
    {
        private readonly PortfolioContext _context;

        public BiographyQuery(PortfolioContext context)
        {
            _context = context;
        }

        public BiographyQueryModel GetItem()
        {
            return _context.Biography.Select(b => new BiographyQueryModel
            {
                Address = b.Address,
                Age = b.Age,
                Birthday = b.Birthday,
                Description = b.Description,
                Email = b.Email,
                Fullname = b.Fullname,
                Languages = b.Languages,
                Mobile = b.Mobile,
                Nationality = b.Nationality,
            }).SingleOrDefault();
        }
    }
}
