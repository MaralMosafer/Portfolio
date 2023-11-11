using _0_Framework.Domain;
using ContactManagement.Application.Contracts.Contact;

namespace ContactManagement.Domain.ContactAgg
{
    public interface IContactRepository : IRepositoryBase<Contact>
    {
        ContactDetail GetDetailBy(long id);
        List<ContactViewModel> Search(ContactSearchModel searchModel);
    }
}