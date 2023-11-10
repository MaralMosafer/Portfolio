namespace AccountManagement.Application.Contracts.Account
{
    public class ChangePassword
    {
        public long Id { get; set; }
        public string Password { get; set; } = string.Empty;
        public string RePassword { get; set; } = string.Empty;
    }
}