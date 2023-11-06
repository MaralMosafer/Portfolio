using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PortfolioManagement.Application.Contracts.Service;

namespace ServiceHost.Areas.Administration.Pages.Service
{
    public class IndexModel : PageModel
    {
        public string Message { get; set; }
        public List<ServiceViewModel> Service { get; set; }
        public IServiceApplication _serviceApplication { get; set; }

        public IndexModel(IServiceApplication serviceApplication)
        {
            _serviceApplication = serviceApplication;
        }

        public void OnGet()
        {
            Service = _serviceApplication.GetAll();
        }
        public RedirectToPageResult OnPostCreate(CreateService command)
        {
            var result = _serviceApplication.Create(command);
            if (!result.IsSucceeded)
                Message = result.Message;
            return RedirectToPage("./Index");
        }
        public RedirectToPageResult OnPostEdit(EditService command)
        {
            _serviceApplication.Edit(command);
            return RedirectToPage("./Index");
        }
        public PartialViewResult OnGetEdit(long id)
        {
            var Service = _serviceApplication.GetDetailsBy(id);
            return Partial("./Edit", Service);
        }
    }
}
