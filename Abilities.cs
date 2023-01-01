namespace KapanGame
{
    enum AbilityType
    {
        DD = 1,
        Heal = 2,
        NoInput = 3,
    }
    class Abilities
    {
        Unit _unit;
        public Abilities(Unit unit)
        {
            _unit = unit;
        }
        public AbilityType PlayerChooseAbility(Unit unit)
        {
            Printer.ChooseAbility();
            ConsoleKey input = Console.ReadKey(true).Key;
            Console.WriteLine();
            switch (input)
            {
                case ConsoleKey.D1:
                    unit.UseMana();
                    Printer.UnitTryDDAttack(unit);
                    return AbilityType.DD;
                case ConsoleKey.D2:
                    unit.UseMana();
                    Printer.UnitHeal(unit);
                    return AbilityType.Heal;
                default:
                    Printer.NoInput();
                    return AbilityType.NoInput;
            }
        }
        public AbilityType EnemyChooseAbility(Unit unit, int input)
        {
            switch (input)
            {
                case 1:
                    unit.UseMana();
                    Printer.UnitTryDDAttack(unit);
                    return AbilityType.DD;
                case 2:
                    unit.UseMana();
                    Printer.UnitHeal(unit);
                    return AbilityType.Heal;
                default:
                    Printer.NoInput();
                    return AbilityType.NoInput;
            }
        }
    }
}
