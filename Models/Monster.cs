

namespace juegoRolesMonstruos
{
    public class Monster
    {
        public string Name { get; set; } = "";
        public MonsterType Type { get; set; }
        public int MaxHp { get; set; }
        public int CurrentHp { get; set; }
        public Dictionary<HeroClass, double> Resistances { get; set; }
        public int ExperienceReward { get; set; }
        public List<Attack> Attacks { get; set; }
        public StatusEffect CurrentEffect { get; set; }
        public int EffectDuration { get; set; }

        public Monster(MonsterType type, int level)
        {
            Type = type;
            Resistances = new Dictionary<HeroClass, double>();
            Attacks = new List<Attack>();
            CurrentEffect = StatusEffect.None;
            EffectDuration = 0;

            switch (type)
            {
                case MonsterType.Goblin:
                    Name = "Goblin";
                    MaxHp = 6 + level * 2;
                    ExperienceReward = 10;
                    Resistances[HeroClass.Archer] = 0.8;
                    Attacks.Add(new Attack("Garra", 1 + level, 3 + level));
                    Attacks.Add(new Attack("Mordisco", 2 + level, 4 + level, AttackSpeed.Normal, StatusEffect.Bleeding, 2));
                    Attacks.Add(new Attack("Salto", 1 + level, 5 + level));
                    break;
                case MonsterType.Orc:
                    Name = "Orc";
                    MaxHp = 12 + level * 3;
                    ExperienceReward = 20;
                    Resistances[HeroClass.Mage] = 0.7;
                    Attacks.Add(new Attack("Mazazo", 2 + level, 5 + level));
                    Attacks.Add(new Attack("Rugido", 1 + level, 3 + level, AttackSpeed.Normal, StatusEffect.Stunned, 1));
                    Attacks.Add(new Attack("Embestida", 3 + level, 6 + level));
                    break;
                case MonsterType.Dragon:
                    Name = "Dragon";
                    MaxHp = 20 + level * 4;
                    ExperienceReward = 50;
                    Resistances[HeroClass.Warrior] = 0.8;
                    Attacks.Add(new Attack("Garra Dragón", 3 + level, 7 + level));
                    Attacks.Add(new Attack("Aliento de Fuego", 2 + level, 6 + level, AttackSpeed.Normal, StatusEffect.Burning, 3));
                    Attacks.Add(new Attack("Cola", 4 + level, 8 + level, AttackSpeed.Normal, StatusEffect.Stunned, 1));
                    break;
                case MonsterType.Undead:
                    Name = "Undead";
                    MaxHp = 8 + level * 2;
                    ExperienceReward = 15;
                    Resistances[HeroClass.Archer] = 0.6;
                    Attacks.Add(new Attack("Toque Helado", 1 + level, 4 + level));
                    Attacks.Add(new Attack("Miasma", 1 + level, 3 + level, AttackSpeed.Normal, StatusEffect.Poisoned, 3));
                    Attacks.Add(new Attack("Lamento", 2 + level, 5 + level, AttackSpeed.Normal, StatusEffect.Stunned, 1));
                    break;
            }
            CurrentHp = MaxHp;
        }

        public (int damage, StatusEffect effect, int duration) Attack(Random rnd)
        {
            var attack = Attacks[rnd.Next(Attacks.Count)];
            int damage = rnd.Next(attack.MinDamage, attack.MaxDamage + 1);
            Console.WriteLine($"{Name} usa {attack.Name}!");
            return (damage, attack.Effect, attack.EffectDuration);
        }

        public int TakeDamage(int damage, HeroClass attackerClass)
        {
            if (Resistances.ContainsKey(attackerClass))
                damage = (int)(damage * Resistances[attackerClass]);

            CurrentHp = Math.Max(0, CurrentHp - damage);
            return damage;
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