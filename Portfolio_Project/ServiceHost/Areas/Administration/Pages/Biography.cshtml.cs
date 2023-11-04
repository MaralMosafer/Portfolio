using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PortfolioManagement.Application.Contracts.Biography;

namespace ServiceHost.Areas.Administration.Pages
{
    public class BiographyModel : PageModel
    {
        public string Message { get; set; }
        public BiographyViewModel Biography { get; set; }
        public IBiographyApplication _biographyApplication { get; set; }

        public BiographyModel(IBiographyApplication biographyApplication)
        {
            _biographyApplication = biographyApplication;
        }

        public void OnGet()
        {
            Biography = _biographyApplication.GetItem();
        }
        public RedirectToPageResult OnPost(CreateBiography command)
        {
            var result = _biographyApplication.Create(command);
            if (!result.IsSucceeded)
                Message = result.Message;
            return RedirectToPage("/Biography");
        }
        public RedirectToPageResult OnPostEdit(EditBiography command)
        {
            _biographyApplication.Edit(command);
            return RedirectToPage("/Biography");
        }
    }
}
