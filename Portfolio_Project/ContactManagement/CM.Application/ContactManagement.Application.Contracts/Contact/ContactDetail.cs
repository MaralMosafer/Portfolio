namespace ContactManagement.Application.Contracts.Contact
{
    public class ContactDetail
    {
        public long Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
    }
}