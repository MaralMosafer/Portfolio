using _0_Framework.Domain;

namespace PortfolioManagement.Domain.SkillAgg
{
    public class Skill : DomainBase
    {
        public string Name { get; private set; } = string.Empty;
        public int Value { get; private set; }

        public Skill(string name, int value)
        {
            Name = name;
            if (value > 100)
                Value = 100;
            else
                Value = value;
        }

        public void Edit(string name, int value)
        {
            Name = name;
            if (value > 100)
                Value = 100;
            else
                Value = value;
        }
    }
}
