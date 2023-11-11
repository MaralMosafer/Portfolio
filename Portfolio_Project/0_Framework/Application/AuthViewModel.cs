namespace _0_Framework.Application
{
    public class AuthViewModel
    {
        public long Id { get; set; }
        public string Fullname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int RoleId { get; set; }

        public AuthViewModel(long id, string fullname, string email)
        {
            Id = id;
            Fullname = fullname;
            Email = email;
            RoleId = RoleType.Administrator;
        }
    }
}
