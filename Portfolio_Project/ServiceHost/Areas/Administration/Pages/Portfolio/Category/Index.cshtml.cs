using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PortfolioManagement.Application.Contracts.WorkSampleCategory;

namespace ServiceHost.Areas.Administration.Pages.Portfolio.Category
{
    public class IndexModel : PageModel
    {
        public string Message { get; set; }
        public List<WorkSampleCategoryViewModel> workSampleCategory { get; set; }
        public IWorkSampleCategoryApplication _workSampleCategoryApplication { get; set; }

        public IndexModel(IWorkSampleCategoryApplication workSampleCategoryApplication)
        {
            _workSampleCategoryApplication = workSampleCategoryApplication;
        }

        public void OnGet()
        {
            workSampleCategory = _workSampleCategoryApplication.GetAll();
        }
        public RedirectToPageResult OnPostCreate(CreateWorkSampleCategory command)
        {
            var result = _workSampleCategoryApplication.Create(command);
            if (!result.IsSucceeded)
                Message = result.Message;
            return RedirectToPage("./Index");
        }
        public RedirectToPageResult OnPostEdit(EditWorkSampleCategory command)
        {
            _workSampleCategoryApplication.Edit(command);
            return RedirectToPage("./Index");
        }
        public PartialViewResult OnGetEdit(long id)
        {
            var WorkSampleCategory = _workSampleCategoryApplication.GetDetails(id);
            return Partial("./Edit", WorkSampleCategory);
        }
    }
}
