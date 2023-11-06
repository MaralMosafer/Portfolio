using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PortfolioManagement.Application.Contracts.Skill;

namespace ServiceHost.Areas.Administration.Pages.Skill
{
    public class IndexModel : PageModel
    {
        public string Message { get; set; }
        public List<SkillViewModel> Skill { get; set; }
        public ISkillApplication _skillApplication { get; set; }

        public IndexModel(ISkillApplication skillApplication)
        {
            _skillApplication = skillApplication;
        }

        public void OnGet()
        {
            Skill = _skillApplication.GetAll();
        }
        public RedirectToPageResult OnPostCreate(CreateSkill command)
        {
            var result = _skillApplication.Create(command);
            if (!result.IsSucceeded)
                Message = result.Message;
            return RedirectToPage("./Index");
        }
        public RedirectToPageResult OnPostEdit(EditSkill command)
        {
            _skillApplication.Edit(command);
            return RedirectToPage("./Index");
        }
        public PartialViewResult OnGetEdit(long id)
        {
            var Skill = _skillApplication.GetDetailsBy(id);
            return Partial("./Edit", Skill);
        }
    }
}
