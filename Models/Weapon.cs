
namespace juegoRolesMonstruos
{
    public class Weapon
    {
        public string Name { get; set; }
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }
        public int Level { get; set; }
        public List<Attack> Attacks { get; set; }

        public Weapon(string name, int minDmg, int maxDmg, int level)
        {
            Name = name;
            MinDamage = minDmg;
            MaxDamage = maxDmg;
            Level = level;
            Attacks = new List<Attack>();
        }
    }
}