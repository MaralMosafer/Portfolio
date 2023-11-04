using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PortfolioManagement.Application.Contracts.Education;

namespace ServiceHost.Areas.Administration.Pages.Education
{
    public class IndexModel : PageModel
    {
        public string Message { get; set; }
        public List<EducationViewModel> Education { get; set; }
        public IEducationApplication _educationApplication { get; set; }

        public IndexModel(IEducationApplication educationApplication)
        {
            _educationApplication = educationApplication;
        }

        public void OnGet()
        {
            Education = _educationApplication.GetAll();
        }
        public RedirectToPageResult OnPostCreate(CreateEducation command)
        {
            var result = _educationApplication.Create(command);
            if (!result.IsSucceeded)
                Message = result.Message;
            return RedirectToPage("./Index");
        }
        public RedirectToPageResult OnPostEdit(EditEducation command)
        {
            _educationApplication.Edit(command);
            return RedirectToPage("./Index");
        }
        public PartialViewResult OnGetEdit(long id)
        {
            var education = _educationApplication.GetDetailsBy(id);
            return Partial("./Edit", education);
        }
    }
}
