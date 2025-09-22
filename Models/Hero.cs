
namespace juegoRolesMonstruos
{
    public class Hero
    {
        public string Name { get; set; }
        public HeroClass Class { get; set; }
        public int MaxHp { get; set; }
        public int CurrentHp { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        public Weapon CurrentWeapon { get; set; }
        public List<Weapon> Weapons { get; set; }
        public StatusEffect CurrentEffect { get; set; }
        public int EffectDuration { get; set; }

        public Hero(HeroTemplate template)
        {
            Name = template.Name;
            Class = template.Class;
            MaxHp = template.MaxHp;
            CurrentHp = MaxHp;
            Level = 1;
            Experience = 0;
            Weapons = new List<Weapon>(template.UniqueWeapons.Select(w => new Weapon(w, 1, 1, 1)));
            CurrentWeapon = Weapons[0];
            CurrentEffect = StatusEffect.None;
            EffectDuration = 0;
        }

        public void LevelUp()
        {
            Level++;
            int hpIncrease = Class == HeroClass.Warrior ? 3 : 2;
            MaxHp += hpIncrease;
            CurrentHp = MaxHp;
            Console.WriteLine($"\n¡{Name} subió al nivel {Level}! HP máximo: {MaxHp}");
        }

        public void ProcessStatusEffect()
        {
            if (CurrentEffect != StatusEffect.None && EffectDuration > 0)
            {
                switch (CurrentEffect)
                {
                    case StatusEffect.Poisoned:
                        CurrentHp = Math.Max(0, CurrentHp - 2);
                        Console.WriteLine($"{Name} sufre 2 de daño por veneno. HP: {CurrentHp}");
                        break;
                    case StatusEffect.Burning:
                        CurrentHp = Math.Max(0, CurrentHp - 3);
                        Console.WriteLine($"{Name} sufre 3 de daño por quemaduras. HP: {CurrentHp}");
                        break;
                    case StatusEffect.Bleeding:
                        CurrentHp = Math.Max(0, CurrentHp - 1);
                        Console.WriteLine($"{Name} sufre 1 de daño por sangrado. HP: {CurrentHp}");
                        break;
                }
                EffectDuration--;
                if (EffectDuration <= 0)
                {
                    Console.WriteLine($"{Name} se recupera del efecto {CurrentEffect}");
                    CurrentEffect = StatusEffect.None;
                }
            }
        }

        public void ApplyStatusEffect(StatusEffect effect, int duration)
        {
            CurrentEffect = effect;
            EffectDuration = duration;
            Console.WriteLine($"{Name} sufre el efecto {effect} por {duration} turnos!");
        }
    }
}