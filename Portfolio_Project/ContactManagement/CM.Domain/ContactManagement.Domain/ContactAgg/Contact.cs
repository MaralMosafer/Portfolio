using _0_Framework.Domain;

namespace ContactManagement.Domain.ContactAgg
{
    public class Contact : DomainBase
    {
        public string Name { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string Subject { get; private set; } = string.Empty;
        public string Message { get; private set; } = string.Empty;
        public bool IsRecived { get; private set; }

        public Contact(string name, string email, string subject, string message)
        {
            Name = name;
            Email = email;
            Subject = subject;
            Message = message;
            IsRecived = false;
        }

        public void Received()
        {
            IsRecived = true;
        }
    }
}