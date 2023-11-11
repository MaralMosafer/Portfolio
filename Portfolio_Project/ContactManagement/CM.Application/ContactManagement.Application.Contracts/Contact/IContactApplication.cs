using _0_Framework.Application;

namespace ContactManagement.Application.Contracts.Contact
{
    public interface IContactApplication
    {
        OperationResult Add(AddContact command);
        ContactDetail GetDetailBy(long id);
        void Recive(long id);
        List<ContactViewModel> Search(ContactSearchModel searchModel);
    }
}