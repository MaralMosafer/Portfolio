using _0_Framework.Application;
using System.ComponentModel.DataAnnotations;

namespace PortfolioManagement.Application.Contracts.Skill
{
    public class CreateSkill
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(100, ErrorMessage = ValidationMessages.MaxLenght)]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        [MaxLength(3, ErrorMessage = ValidationMessages.MaxLenght)]
        public int Value { get; set; }
    }
}
