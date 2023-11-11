using AccountManagement.Application.Contracts.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Account
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        public List<AccountViewModel> Accounts { get; set; }
        public IAccountApplication _accountApplication { get; set; }

        public IndexModel(IAccountApplication accountApplication)
        {
            _accountApplication = accountApplication;
        }

        public void OnGet()
        {
            Accounts = _accountApplication.GetAll();
        }
        public RedirectToPageResult OnPostCreate(CreateAccount command)
        {
            var result = _accountApplication.Create(command);
            if (!result.IsSucceeded)
                Message = result.Message;
            return RedirectToPage("./Index");
        }
        public RedirectToPageResult OnPostEdit(EditAccount command)
        {
            _accountApplication.Edit(command);
            return RedirectToPage("./Index");
        }
        public PartialViewResult OnGetEdit(long id)
        {
            var Account = _accountApplication.GetDetailsBy(id);
            return Partial("./Edit", Account);
        }
        public PartialViewResult OnGetChangePassword(long id)
        {
            var Account = new ChangePassword { Id = id };
            return Partial("./ChangePassword", Account);
        }
        public RedirectToPageResult OnPostChangePassword(ChangePassword command)
        {
            var result=_accountApplication.ChangePassword(command);
            if (!result.IsSucceeded)
                Message = result.Message;
            return RedirectToPage("./Index");
        }
    }
}
