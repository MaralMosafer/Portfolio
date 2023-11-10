using _0_Framework.Domain;

namespace PortfolioManagement.Domain.InformationAgg
{
	public class Information : DomainBase
	{
		public string Name { get; private set; } = string.Empty;
		public string Family { get; private set; } = string.Empty;
		public string Biography { get; private set; } = string.Empty;
		public string Address { get; private set; } = string.Empty;
		public string Email { get; private set; } = string.Empty;
		public string Mobile { get; private set; } = string.Empty;
		public string Picture { get; private set; } = string.Empty;
		public string PictureAlt { get; private set; } = string.Empty;
		public string PictureTitle { get; private set; } = string.Empty;

		public Information(string name, string family, string biography, string address, string email, string mobile, string picture, string pictureAlt, string pictureTitle)
		{
			Name = name;
			Family = family;
			Biography = biography;
			Address = address;
			Email = email;
			Mobile = mobile;
			Picture = picture;
			PictureAlt = pictureAlt;
			PictureTitle = pictureTitle;
		}

		public void Edit(string name, string family, string biography, string address, string email, string mobile, string picture, string pictureAlt, string pictureTitle)
		{
			Name = name;
			Family = family;
			Biography = biography;
			Address = address;
			Email = email;
			Mobile = mobile;
			if (!string.IsNullOrWhiteSpace(picture))
				Picture = picture;
			PictureAlt = pictureAlt;
			PictureTitle = pictureTitle;
		}
	}
}