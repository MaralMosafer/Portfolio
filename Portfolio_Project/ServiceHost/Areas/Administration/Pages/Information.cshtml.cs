using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PortfolioManagement.Application.Contracts.Information;

namespace ServiceHost.Areas.Administration.Pages
{
    public class InformationModel : PageModel
    {
        public string Message { get; set; }
        public InformationViewModel Information { get; set; }
        public IInformationApplication _informationApplication { get; set; }

        public InformationModel(IInformationApplication informationApplication)
        {
            _informationApplication = informationApplication;
        }

        public void OnGet()
        {
            Information = _informationApplication.GetItem();
        }
        public RedirectToPageResult OnPost(CreateInformation command)
        {
            var result = _informationApplication.Create(command);
            if (!result.IsSucceeded)
                Message = result.Message;
            return RedirectToPage("/Information");
        }
        public RedirectToPageResult OnPostEdit(EditInformation command)
        {
            _informationApplication.Edit(command);
            return RedirectToPage("/Information");
        }
    }
}
