using _0_Framework.Domain;
using AccountManagement.Application.Contracts.Account;

namespace AccountManagement.Domain.AccountAgg
{
    public interface IAccountRepository : IRepositoryBase<Account>
    {
        EditAccount GetDetailsBy(long id);
        List<AccountViewModel> GetAll();
    }
}