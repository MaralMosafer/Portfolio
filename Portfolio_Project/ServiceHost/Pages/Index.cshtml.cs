using ContactManagement.Application.Contracts.Contact;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IContactApplication _contactApplication;

        public IndexModel(IContactApplication contactApplication)
        {
            _contactApplication = contactApplication;
        }

        public void OnGet()
        {
        }
        public RedirectToPageResult OnPost(AddContact command)
        {
            _contactApplication.Add(command);
            return RedirectToPage("./Index");
        }
    }
}