using _0_Framework.Infrastructure;
using ContactManagement.Application.Contracts.Contact;
using ContactManagement.Domain.ContactAgg;

namespace ContactManagement.Infrastructure.Repositories
{
    public class ContactRepository : RepositoryBase<Contact>, IContactRepository
    {
        private readonly ContactContext _context;
        public ContactRepository(ContactContext context) : base(context)
        {
            _context = context;
        }

        public ContactDetail GetDetailBy(long id)
        {
            return _context.Contacts.Select(x => new ContactDetail
            {
                Id = x.Id,
                Email = x.Email,
                Message = x.Message
            }).FirstOrDefault(c => c.Id == id);
        }

        public List<ContactViewModel> Search(ContactSearchModel searchModel)
        {
            var query = _context.Contacts.Select(c => new ContactViewModel
            {
                Id = c.Id,
                CreationDate = c.CreationDate.ToString(),
                IsRecived = c.IsRecived,
                Name = c.Name,
                Subject = c.Subject
            });

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            if (searchModel.IsRecived)
                query = query.Where(x => !x.IsRecived);

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
