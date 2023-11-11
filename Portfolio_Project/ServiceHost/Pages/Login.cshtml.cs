using _0_Framework.Application;
using AccountManagement.Application.Contracts.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class LoginModel : PageModel
    {
        [TempData]
        public string Message { get; set; } = string.Empty;
        private readonly IAccountApplication _accountApplication;
        private readonly IAuthHelper _authHelper;

        public LoginModel(IAccountApplication accountApplication, IAuthHelper authHelper)
        {
            _accountApplication = accountApplication;
            _authHelper = authHelper;
        }

        public void OnGet()
        {
        }
        public IActionResult OnPostLogin(Login command)
        {
            var result = _accountApplication.Login(command);
            if (!result.IsSucceeded)
            {
                Message = result.Message;
                return RedirectToPage("./Login");
            }
            return RedirectToPage("./Index");
        }
        public RedirectToPageResult OnGetLogout()
        {
            _authHelper.Signout();
            return RedirectToPage("/Index");
        }
    }
}
