namespace KapanGame
{
    class Unit
    {
        public string Name { get; set; }
        public int MaxHP { get; private set; }
        public int CurrentHP { get; set; }
        public int Damage { get; private set; }
        public int CurrentShield { get; set; }
        public int MaxShield { get; private set; }
        public int Mana { get; set; }
        public bool Parring { get; set; } = false;
        public bool Stunned { get; set; } = false;
        public Unit(string name, int hp, int shield, int damage, int mana)
        {
            Name = name;
            MaxHP = hp;
            CurrentHP = MaxHP;
            MaxShield = shield;
            CurrentShield = MaxShield;
            Damage = damage;
            Mana = mana;
        }
        public int Attack()
        {
            return Damage;
        }
        public void TakeDamage(int damage)
        {
            if (damage == 0)
                return;
            if (CurrentShield > 0)
            {
                int block = CurrentShield;
                CurrentShield -= damage;
                if (CurrentShield < 0) CurrentShield = 0;
                damage -= block;
                if (damage < 0) damage = 0;
            }
            CurrentHP -= damage;
            if (CurrentHP < 0) CurrentHP = 0;
        }
        public void GetKicked()
        {
            CurrentHP -= 1;
            if (CurrentHP < 0) CurrentHP = 0;
        }
        public void GetKickedFall()
        {
            CurrentHP -= 2;
            if (CurrentHP < 0) CurrentHP = 0;
        }
        public void Heal(int heal)
        {
            if (heal < 0)
                return;
            CurrentHP += heal;
            if (CurrentHP > MaxHP) CurrentHP = MaxHP;
        }
        public void UseMana()
        {
            if (Mana < 0)
                return;
            Mana -= 1;
            if (Mana < 0) Mana = 0;
        }
        public void Parry()
        {
            Parring = true;
        }
        public bool IsDead()
        {
            if (CurrentHP == 0) return true;
            return false;
        }

    }
}