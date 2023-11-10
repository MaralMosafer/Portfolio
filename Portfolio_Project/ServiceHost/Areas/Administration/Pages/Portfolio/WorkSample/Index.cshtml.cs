using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PortfolioManagement.Application.Contracts.WorkSample;
using PortfolioManagement.Application.Contracts.WorkSampleCategory;

namespace ServiceHost.Areas.Administration.Pages.Portfolio.WorkSample
{
    public class IndexModel : PageModel
    {
        public string Message { get; set; }
        public List<WorkSampleViewModel> workSample { get; set; }
        public SelectList Categories { get; set; }
        private readonly IWorkSampleApplication _workSampleApplication;
        private readonly IWorkSampleCategoryApplication _workSampleCategoryApplication;

        public IndexModel(IWorkSampleApplication workSampleApplication, IWorkSampleCategoryApplication workSampleCategoryApplication = null)
        {
            _workSampleApplication = workSampleApplication;
            _workSampleCategoryApplication = workSampleCategoryApplication;
        }

        public void OnGet()
        {
            Categories = new SelectList(_workSampleCategoryApplication.GetAll(), "Id", "Name");
            workSample = _workSampleApplication.GetAll();
        }
        public RedirectToPageResult OnPostCreate(CreateWorkSample command)
        {
            var result = _workSampleApplication.Create(command);
            if (!result.IsSucceeded)
                Message = result.Message;
            return RedirectToPage("./Index");
        }
        public RedirectToPageResult OnPostEdit(EditWorkSample command)
        {
            _workSampleApplication.Edit(command);
            return RedirectToPage("./Index");
        }
        public PartialViewResult OnGetEdit(long id)
        {
            var workSample = _workSampleApplication.GetDetailsBy(id);
            workSample.Categories = _workSampleCategoryApplication.GetAll();
            return Partial("./Edit", workSample);
        }
        public RedirectToPageResult OnGetRemove(long id)
        {
            _workSampleApplication.Remove(id);
            return RedirectToPage("./Index");
        }
        public RedirectToPageResult OnGetActive(long id)
        {
            _workSampleApplication.Active(id);
            return RedirectToPage("./Index");
        }
    }
}
