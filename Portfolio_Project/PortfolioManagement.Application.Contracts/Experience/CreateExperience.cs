using _0_Framework.Application;
using System.ComponentModel.DataAnnotations;

namespace PortfolioManagement.Application.Contracts.Experience
{
    public class CreateExperience
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(100, ErrorMessage = ValidationMessages.MaxLenght)]
        public string Title { get; set; } = string.Empty;
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(100, ErrorMessage = ValidationMessages.MaxLenght)]
        public string Place { get; set; } = string.Empty;
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(200, ErrorMessage = ValidationMessages.MaxLenght)]
        public string Description { get; set; } = string.Empty;
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(20, ErrorMessage = ValidationMessages.MaxLenght)]
        public string StartDate { get; set; } = string.Empty;
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(20, ErrorMessage = ValidationMessages.MaxLenght)]
        public string EndDate { get; set; } = string.Empty;
    }
}
