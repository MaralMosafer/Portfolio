using _0_Framework.Domain;
using BlogManagement.Domain.ArticleCategoryAgg;

namespace BlogManagement.Domain.ArticleAgg
{
    public class Article : DomainBase
    {
        public string Title { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public string Picture { get; private set; } = string.Empty;
        public string PictureAlt { get; private set; } = string.Empty;
        public string PictureTitle { get; private set; } = string.Empty;
        public long CategoryId { get; private set; }
        public ArticleCategory Category { get; private set; }
        public bool IsActive { get; private set; }

        public Article(string title, string description, string picture, string pictureAlt, string pictureTitle, long categoryId)
        {
            Title = title;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            CategoryId = categoryId;
            IsActive = true;
        }
        public void Edit(string title, string description, string picture, string pictureAlt, string pictureTitle, long categoryId)
        {
            Title = title;
            Description = description;
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
