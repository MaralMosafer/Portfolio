using _0_Framework.Infrastructure;
using PortfolioManagement.Application.Contracts.Biography;
using PortfolioManagement.Domain.BiographyAgg;

namespace ProjectManagement.Infrastructure.Repositories
{
    public class BiographyRepository : RepositoryBase<Biography>, IBiographyRepository
    {
        private readonly PortfolioContext _context;
        public BiographyRepository(PortfolioContext context) : base(context)
        {
            _context = context;
        }

        public EditBiography GetDetails(long id)
        {
            return _context.Biography.Select(b => new EditBiography
            {
                Id = b.Id,
                Address = b.Address,
                Age = b.Age,
                Birthday = b.Birthday,
                Description = b.Description,
                Email = b.Email,
                Fullname = b.Fullname,
                Languages = b.Languages,
                Mobile = b.Mobile,
                Nationality = b.Nationality
            }).FirstOrDefault(b => b.Id == id);
        }

        public BiographyViewModel GetItem()
        {
            return _context.Biography.Select(b => new BiographyViewModel
            {
                Id = b.Id,
                Adress = b.Address,
                Age = b.Age,
                Birthday = b.Birthday,
                Description = b.Description,
                Email = b.Email,
                Fullname = b.Fullname,
                Languages = b.Languages,
                Mobile = b.Mobile,
                Nationality = b.Nationality
            }).SingleOrDefault();
        }
    }
}
