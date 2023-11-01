using _0_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using PortfolioManagement.Application.Contracts.Information;
using PortfolioManagement.Domain.InformationAgg;

namespace ProjectManagement.Infrastructure.Repositories
{
    public class InformationRepository : RepositoryBase<Information>, IInformationRepository
    {
        private readonly PortfolioContext _context;
        public InformationRepository(PortfolioContext context) : base(context)
        {
            _context = context;
        }

        public EditInformation GetDetailsBy(long id)
        {
            return _context.Information.Select(i => new EditInformation
            {
                Id = i.Id,
                Name = i.Name,
                Email = i.Email,
                Family = i.Family,
                Address = i.Address,
                Picture = i.Picture,
                Biography = i.Biography,
                PictureAlt = i.PictureAlt,
                PictureTitle = i.PictureTitle
            }).FirstOrDefault(i => i.Id == id);
        }

        public InformationViewModel GetItem()
        {
            return _context.Information.Select(i => new InformationViewModel
            {
                Id = i.Id,
                Name = i.Name,
                Family = i.Family,
                Picture = i.Picture,
            }).SingleOrDefault();
        }
    }
}
