namespace _0_Framework.Domain
{
    public class DomainBase
    {
        public long Id { get; set; }
        public DateTime CreationDate { get; set; }

        public DomainBase() => CreationDate = DateTime.Now;
    }
}