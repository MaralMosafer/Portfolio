using _0_Framework.Domain;
using PortfolioManagement.Domain.WorkSampleCategoryAgg;

namespace PortfolioManagement.Domain.WorkSampleAgg
{
    public class WorkSample : DomainBase
    {
        public string Name { get; private set; } = string.Empty;
        public string Picture { get; private set; } = string.Empty;
        public string PictureAlt { get; private set; } = string.Empty;
        public string PictureTitle { get; private set; } = string.Empty;
        public bool IsActive { get; private set; }
        public long CategoryId { get; private set; }
        public WorkSampleCategory Category { get; private set; }

        public WorkSample(string name, string picture, string pictureAlt, string pictureTitle, long categoryId)
        {
            Name = name;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            CategoryId = categoryId;
            IsActive = true;
        }
        public void Edit(string name, string picture, string pictureAlt, string pictureTitle, long categoryId)
        {
            Name = name;
            if (!string.IsNullOrWhiteSpace(picture))
                Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            CategoryId = categoryId;
        }
        public void Active()
        {
            IsActive = true;
        }
        public void Remove()
        {
            IsActive = false;
        }
    }
}
