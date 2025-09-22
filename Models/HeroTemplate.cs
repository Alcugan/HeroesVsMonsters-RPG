
namespace juegoRolesMonstruos
{
    public class HeroTemplate
    {
        public string Name { get; set; }
        public HeroClass Class { get; set; }
        public int MaxHp { get; set; }
        public int DamageMultiplier { get; set; }
               public string Description { get; set; }
        public List<string> UniqueWeapons { get; set; }

        public HeroTemplate(string name, HeroClass heroClass, int maxHp, int damageMultiplier,
                            string description, params string[] weapons)
        {
            Name = name;
            Class = heroClass;
            MaxHp = maxHp;
            DamageMultiplier = damageMultiplier;
            Description = description;
            UniqueWeapons = weapons.ToList();
        }
    }
}