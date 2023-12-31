﻿using Microsoft.AspNetCore.Http;

namespace BlogManagement.Application.Contracts.Article
{
    public class CreateArticle
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public IFormFile Picture { get; set; }
        public string PictureAlt { get; set; } = string.Empty;
        public string PictureTitle { get; set; } = string.Empty;
        public long CategoryId { get; set; }
    }
}
