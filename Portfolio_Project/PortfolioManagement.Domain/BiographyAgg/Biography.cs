using _0_Framework.Domain;

namespace PortfolioManagement.Domain.BiographyAgg
{
    public class Biography : DomainBase
    {
        public string Description { get; private set; } = string.Empty;
        public string Fullname { get; private set; } = string.Empty;
        public string Birthday { get; private set; } = string.Empty;
        public int Age { get; private set; }
        public string Languages { get; private set; } = string.Empty;
        public string Nationality { get; private set; } = string.Empty;
        public string Adress { get; private set; } = string.Empty;
        public string Mobile { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;


        public Biography(string description, string fullname, string birthday, int age, string languages, string nationality, string adress, string mobile, string email)
        {
            Description = description;
            Fullname = fullname;
            Birthday = birthday;
            Age = age;
            Languages = languages;
            Nationality = nationality;
            Adress = adress;
            Mobile = mobile;
            Email = email;
        }
        public void Edit(string description, string fullname, string birthday, int age, string languages, string nationality, string adress, string mobile, string email)
        {
            Description = description;
            Fullname = fullname;
            Birthday = birthday;
            Age = age;
            Languages = languages;
            Nationality = nationality;
            Adress = adress;
            Mobile = mobile;
            Email = email;
        }
    }
}
