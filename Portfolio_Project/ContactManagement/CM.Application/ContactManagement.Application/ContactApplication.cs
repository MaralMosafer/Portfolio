using ContactManagement.Application.Contracts.Contact;
using _0_Framework.Application;
using ContactManagement.Domain.ContactAgg;

namespace ContactManagement.Application
{
    public class ContactApplication : IContactApplication
    {
        private readonly IContactRepository _contactRepository;

        public ContactApplication(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public OperationResult Add(AddContact command)
        {
            var operationResult = new OperationResult();
            var contact = new Contact(command.Name, command.Email, command.Subject, command.Message);
            _contactRepository.CreateAndSave(contact);
            _contactRepository.SaveChanges();
            return operationResult.Successful(ApplicationMessages.ContactUs);
        }

        public ContactDetail GetDetailBy(long id)
        {
            return _contactRepository.GetDetailBy(id);
        }

        public void Recive(long id)
        {
            var contact = _contactRepository.GetBy(id);
            contact.Received();
            _contactRepository.SaveChanges();
        }

        public List<ContactViewModel> Search(ContactSearchModel searchModel)
        {
            return _contactRepository.Search(searchModel);
        }
    }
}