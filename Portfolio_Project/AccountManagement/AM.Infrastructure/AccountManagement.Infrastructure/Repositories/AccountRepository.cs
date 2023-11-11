using _0_Framework.Infrastructure;
using AccountManagement.Application.Contracts.Account;
using AccountManagement.Domain.AccountAgg;

namespace AccountManagement.Infrastructure.Repositories
{
    public class AccountRepository : RepositoryBase<Account>, IAccountRepository
    {
        private readonly AccountContext _context;
        public AccountRepository(AccountContext context) : base(context)
        {
            _context = context;
        }

        public List<AccountViewModel> GetAll()
        {
            return _context.Accounts.Select(a => new AccountViewModel
            {
                Id = a.Id,
                Email = a.Email,
                Fullname = a.Fullname,
                ProfilePicture = a.ProfilePicture,
            }).ToList();
        }

        public EditAccount GetDetailsBy(long id)
        {
            return _context.Accounts.Select(a => new EditAccount
            {
                Id = a.Id,
                Email = a.Email,
                Fullname = a.Fullname,
            }).FirstOrDefault(a => a.Id == id);
        }
    }
}
