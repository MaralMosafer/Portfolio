using AccountManagement.Application.Contracts.Account;
using _0_Framework.Application;
using AccountManagement.Domain.AccountAgg;

namespace AccountManagement.Application
{
    public class AccountApplication : IAccountApplication
    {
        private readonly IFileUploader _fileUploader;
        private readonly IAccountRepository _accountRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IAuthHelper _authHelper;

        public AccountApplication(IFileUploader fileUploader, IAccountRepository accountRepository, IPasswordHasher passwordHasher, IAuthHelper authHelper)
        {
            _fileUploader = fileUploader;
            _accountRepository = accountRepository;
            _passwordHasher = passwordHasher;
            _authHelper = authHelper;
        }

        public OperationResult ChangePassword(ChangePassword command)
        {
            var operationResult = new OperationResult();
            var account = _accountRepository.GetBy(command.Id);
            if (account == null)
                return operationResult.Failed(ApplicationMessages.NotFound);
            if (command.Password != command.RePassword)
                return operationResult.Failed(ApplicationMessages.PasswordNotMatch);

            var password = _passwordHasher.Hash(command.Password);
            account.ChangePassword(password);
            _accountRepository.SaveChanges();
            return operationResult.Successful();
        }

        public OperationResult Create(CreateAccount command)
        {
            var operationResult = new OperationResult();
            var file = _fileUploader.Upload(command.ProfilePicture, "profilePictures");
            var password = _passwordHasher.Hash(command.Password);

            if (_accountRepository.Exists(x => x.Email == command.Email))
                return operationResult.Failed(ApplicationMessages.Duplicated);

            var account = new Account(command.Fullname, command.Email, password, file);
            _accountRepository.CreateAndSave(account);
            _accountRepository.SaveChanges();
            return operationResult.Successful();
        }

        public OperationResult Edit(EditAccount command)
        {
            var operationResult = new OperationResult();
            var file = _fileUploader.Upload(command.ProfilePicture, "profilePictures");
            var account = _accountRepository.GetBy(command.Id);
            var password = _passwordHasher.Hash(command.Password);

            if (_accountRepository.Exists(x => x.Email == command.Email && x.Id != command.Id))
                return operationResult.Failed(ApplicationMessages.Duplicated);
            if (account == null)
                return operationResult.Failed(ApplicationMessages.NotFound);

            account.Edit(command.Fullname, command.Email, password, file);
            _accountRepository.SaveChanges();
            return operationResult.Successful();
        }

        public List<AccountViewModel> GetAll()
        {
            return _accountRepository.GetAll();
        }

        public EditAccount GetDetailsBy(long id)
        {
            return _accountRepository.GetDetailsBy(id);
        }

        public OperationResult Login(Login command)
        {
            var operationResult = new OperationResult();
            //Is User Exists?
            var account = _accountRepository.GetBy(command.Email);
            if (account == null)
                return operationResult.Failed(ApplicationMessages.WrongUsername);

            //Is Password correct?
            (bool Verified, bool NeedsUpgrade) result = _passwordHasher.Check(account.Password, command.Password);
            if (!result.Verified)
                return operationResult.Failed(ApplicationMessages.WrongPassword);

            //Login
            var accountViewModel = new AuthViewModel(account.Id, account.Fullname, account.Email);
            _authHelper.Signin(accountViewModel);
            return operationResult.Successful();
        }
    }
}