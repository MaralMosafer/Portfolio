using _0_Framework.Domain;
using PortfolioManagement.Domain.WorkSampleCategoryAgg;

namespace PortfolioManagement.Domain.WorkSampleAgg
{
    public class WorkSample : DomainBase
    {
        public string Title { get; private set; } = string.Empty;
        public string Picture { get; private set; } = string.Empty;
        public string PictureAlt { get; private set; } = string.Empty;
        public string PictureTitle { get; private set; } = string.Empty;
        public bool IsActive { get; private set; }
        public long CategoryId { get; private set; }
        public WorkSampleCategory Category { get; private set; }

        public WorkSample(string title, string picture, string pictureAlt, string pictureTitle, long categoryId)
        {
            Title = title;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            CategoryId = categoryId;
            IsActive = true;
        }
        public void Edit(string title, string picture, string pictureAlt, string pictureTitle, long categoryId)
        {
            Title = title;
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
