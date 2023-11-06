using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PortfolioManagement.Application.Contracts.Experience;

namespace ServiceHost.Areas.Administration.Pages.Experience
{
    public class IndexModel : PageModel
    {
        public string Message { get; set; }
        public List<ExperienceViewModel> Experience { get; set; }
        public IExperienceApplication _experienceApplication { get; set; }

        public IndexModel(IExperienceApplication experienceApplication)
        {
            _experienceApplication = experienceApplication;
        }

        public void OnGet()
        {
            Experience = _experienceApplication.GetAll();
        }
        public RedirectToPageResult OnPostCreate(CreateExperience command)
        {
            var result = _experienceApplication.Create(command);
            if (!result.IsSucceeded)
                Message = result.Message;
            return RedirectToPage("./Index");
        }
        public RedirectToPageResult OnPostEdit(EditExperience command)
        {
            _experienceApplication.Edit(command);
            return RedirectToPage("./Index");
        }
        public PartialViewResult OnGetEdit(long id)
        {
            var Experience = _experienceApplication.GetDetailsBy(id);
            return Partial("./Edit", Experience);
        }
    }
}
