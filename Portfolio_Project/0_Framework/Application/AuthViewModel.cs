namespace _0_Framework.Application
{
    public class AuthViewModel
    {
        public long Id { get; set; }
        public string Fullname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int RoleId { get; set; }
        public string Profile { get; set; } = string.Empty;

        public AuthViewModel()
        {

        }
        public AuthViewModel(long id, string fullname, string email, string profile)
        {
            Id = id;
            Fullname = fullname;
            Email = email;
            RoleId = RoleType.Administrator;
            Profile = profile;
        }
    }
}
