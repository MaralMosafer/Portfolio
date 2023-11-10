using _0_Framework.Application;
using _0_Framework.Domain;

namespace AccountManagement.Domain.AccountAgg
{
    public class Account : DomainBase
    {
        public string Fullname { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string Password { get; private set; } = string.Empty;
        public string ProfilePicture { get; private set; } = string.Empty;
        public int RoleId { get; private set; }

        public Account(string fullname, string email, string password, string profilePicture)
        {
            Fullname = fullname;
            Email = email;
            Password = password;
            ProfilePicture = profilePicture;
            RoleId = RoleType.Administrator;
        }
        public void Edit(string fullname, string email, string password,string profilePicture)
        {
            Fullname = fullname;
            Email = email;
            Password = password;
            if (!string.IsNullOrWhiteSpace(profilePicture))
                ProfilePicture = profilePicture;
            RoleId = RoleType.Administrator;
        }
        public void ChangePassword(string password)
        {
            Password = password;
        }
    }
}