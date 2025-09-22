
namespace juegoRolesMonstruos
{
    public class Attack
    {
        public string Name { get; set; }
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }
        public StatusEffect Effect { get; set; }
        public int EffectDuration { get; set; }
        public char HotKey { get; set; }
        public AttackSpeed Speed { get; set; }

        public Attack(string name, int minDmg, int maxDmg, AttackSpeed speed = AttackSpeed.Normal,
                      StatusEffect effect = StatusEffect.None, int duration = 0, char hotKey = 'A')
        {
            Name = name;
            MinDamage = minDmg;
            MaxDamage = maxDmg;
            Speed = speed;
            Effect = effect;
            EffectDuration = duration;
            HotKey = hotKey;
        }
    }
}