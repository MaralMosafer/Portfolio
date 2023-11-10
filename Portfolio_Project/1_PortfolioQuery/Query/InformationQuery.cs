using _1_PortfolioQuery.Contracts.InformationModel;
using ProjectManagement.Infrastructure;

namespace _1_PortfolioQuery.Query
{
	public class InformationQuery : IInformationQuery
	{
		private readonly PortfolioContext _context;

		public InformationQuery(PortfolioContext context)
		{
			_context = context;
		}

		public InformationQueryModel GetItem()
		{
			return _context.Information.Select(i => new InformationQueryModel
			{
				Name = i.Name,
				Family = i.Family,
				Picture = i.Picture,
				Biography = i.Biography,
				Address = i.Address,
				Email = i.Email,
				PictureAlt = i.PictureAlt,
				PictureTitle = i.PictureTitle,
				Mobile = i.Mobile
			}).SingleOrDefault();
		}
	}
}
