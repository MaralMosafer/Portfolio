namespace ContactManagement.Application.Contracts
{
    public class ContactViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string CreationDate { get; set; } = string.Empty;
        public bool IsRecived { get; set; }
    }
}