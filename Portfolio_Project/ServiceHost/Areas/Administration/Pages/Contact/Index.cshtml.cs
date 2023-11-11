using ContactManagement.Application.Contracts.Contact;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Contact
{
    public class IndexModel : PageModel
    {
        public List<ContactViewModel> Contacts { get; set; }
        public ContactSearchModel SearchModel { get; set; }
        private readonly IContactApplication _contactApplication;

        public IndexModel(IContactApplication contactApplication)
        {
            _contactApplication = contactApplication;
        }

        public void OnGet(ContactSearchModel searchModel)
        {
            Contacts = _contactApplication.Search(searchModel);
        }
        public IActionResult OnGetDetail(long id)
        {
            var contact = _contactApplication.GetDetailBy(id);
            return Partial("./Detail", contact);
        }
        public IActionResult OnGetRecive(long id)
        {
            _contactApplication.Recive(id);
            return RedirectToPage("./Index");
        }
    }
}
