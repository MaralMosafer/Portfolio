using _0_Framework.Application;
using System.ComponentModel.DataAnnotations;

namespace PortfolioManagement.Application.Contracts.Service
{
    public class CreateService
    {
        [Required(ErrorMessage =ValidationMessages.IsRequired)]
        [MaxLength(150,ErrorMessage =ValidationMessages.MaxLenght)]
        public string Title { get; set; } = string.Empty;
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(300, ErrorMessage = ValidationMessages.MaxLenght
        public string Description { get; set; } = string.Empty;
        public float Price { get; set; }
    }
}
