using _0_Framework.Application;
using System.ComponentModel.DataAnnotations;

namespace PortfolioManagement.Application.Contracts.Biography
{
    public class CreateBiography
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(500, ErrorMessage = ValidationMessages.MaxLenght)]
        public string Description { get; set; } = string.Empty;
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(160, ErrorMessage = ValidationMessages.MaxLenght)]
        public string Fullname { get; set; } = string.Empty;
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(50, ErrorMessage = ValidationMessages.MaxLenght)]
        public string Birthday { get; set; } = string.Empty;
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public int Age { get; set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(80, ErrorMessage = ValidationMessages.MaxLenght)]
        public string Languages { get; set; } = string.Empty;
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(50, ErrorMessage = ValidationMessages.MaxLenght)]
        public string Nationality { get; set; } = string.Empty;
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(80, ErrorMessage = ValidationMessages.MaxLenght)]
        public string Address { get; set; } = string.Empty;
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(20, ErrorMessage = ValidationMessages.MaxLenght)]
        public string Mobile { get; set; } = string.Empty;
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(50, ErrorMessage = ValidationMessages.MaxLenght)]
        public string Email { get; set; } = string.Empty;
    }
}
