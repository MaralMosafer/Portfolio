using _0_Framework.Application;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace PortfolioManagement.Application.Contracts.Information
{
    public class CreateInformation
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(80, ErrorMessage = ValidationMessages.MaxLenght)]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(80, ErrorMessage = ValidationMessages.MaxLenght)]
        public string Family { get; set; } = string.Empty;
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(100, ErrorMessage = ValidationMessages.MaxLenght)]
        public string Biography { get; set; } = string.Empty;
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(500, ErrorMessage = ValidationMessages.MaxLenght)]
        public string Address { get; set; } = string.Empty;
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(300, ErrorMessage = ValidationMessages.MaxLenght)]
        public string Email { get; set; } = string.Empty;
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public IFormFile Picture { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(100, ErrorMessage = ValidationMessages.MaxLenght)]
        public string PictureAlt { get; set; } = string.Empty;
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(100, ErrorMessage = ValidationMessages.MaxLenght)]
        public string PictureTitle { get; set; } = string.Empty;
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(25, ErrorMessage = ValidationMessages.MaxLenght)]
        public string Mobile { get; set; } = string.Empty;
	}
}