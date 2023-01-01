using System;

namespace KapanGame
{
    static class Printer
    {
        public static ConsoleColor background = ConsoleColor.Black;
        public static ConsoleColor foreground = ConsoleColor.White;
        public static void Welcome()
        {
            Console.Write(@"
██╗    ██╗███████╗██╗      ██████╗ ██████╗ ███╗   ███╗███████╗    ████████╗ ██████╗ 
██║    ██║██╔════╝██║     ██╔════╝██╔═══██╗████╗ ████║██╔════╝    ╚══██╔══╝██╔═══██╗
██║ █╗ ██║█████╗  ██║     ██║     ██║   ██║██╔████╔██║█████╗         ██║   ██║   ██║
██║███╗██║██╔══╝  ██║     ██║     ██║   ██║██║╚██╔╝██║██╔══╝         ██║   ██║   ██║
╚███╔███╔╝███████╗███████╗╚██████╗╚██████╔╝██║ ╚═╝ ██║███████╗       ██║   ╚██████╔╝
 ╚══╝╚══╝ ╚══════╝╚══════╝ ╚═════╝ ╚═════╝ ╚═╝     ╚═╝╚══════╝       ╚═╝    ╚═════╝ ");

        }
        public static void Kapan()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(20, 7);
            Console.Write("██╗  ██╗");
            Console.SetCursorPosition(20, 8);
            Console.Write("██║ ██╔╝");
            Console.SetCursorPosition(20, 9);
            Console.Write("█████╔╝ ");
            Console.SetCursorPosition(20, 10);
            Console.Write("██╔═██╗ ");
            Console.SetCursorPosition(20, 11);
            Console.Write("██║  ██╗");
            Console.SetCursorPosition(20, 12);
            Console.Write("╚═╝  ╚═╝");
        
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(28, 7);
            Console.Write(" █████╗ ");
            Console.SetCursorPosition(28, 8);
            Console.Write("██╔══██╗");
            Console.SetCursorPosition(28, 9);
            Console.Write("███████║");
            Console.SetCursorPosition(28, 10);
            Console.Write("██╔══██║");
            Console.SetCursorPosition(28, 11);
            Console.Write("██║  ██║");
            Console.SetCursorPosition(28, 12);
            Console.Write("╚═╝  ╚═╝");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(36, 7);
            Console.Write("██████╗ ");
            Console.SetCursorPosition(36, 8);
            Console.Write("██╔══██╗");
            Console.SetCursorPosition(36, 9);
            Console.Write("██████╔╝");
            Console.SetCursorPosition(36, 10);
            Console.Write("██╔═══╝ ");
            Console.SetCursorPosition(36, 11);
            Console.Write("██║     ");
            Console.SetCursorPosition(36, 12);
            Console.Write("╚═╝     ");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(44, 7);
            Console.Write(" █████╗ ");
            Console.SetCursorPosition(44, 8);
            Console.Write("██╔══██╗");
            Console.SetCursorPosition(44, 9);
            Console.Write("███████║");
            Console.SetCursorPosition(44, 10);
            Console.Write("██╔══██║");
            Console.SetCursorPosition(44, 11);
            Console.Write("██║  ██║");
            Console.SetCursorPosition(44, 12);
            Console.Write("╚═╝  ╚═╝");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(52, 7);
            Console.Write("███╗   ██╗");
            Console.SetCursorPosition(52, 8);
            Console.Write("████╗  ██║");
            Console.SetCursorPosition(52, 9);
            Console.Write("██╔██╗ ██║");
            Console.SetCursorPosition(52, 10);
            Console.Write("██║╚██╗██║");
            Console.SetCursorPosition(52, 11);
            Console.Write("██║ ╚████║");
            Console.SetCursorPosition(52, 12);
            Console.Write("╚═╝  ╚═══╝");
            Console.ForegroundColor = foreground;
            Console.WriteLine();
        }
        public static void Round(int round, ConsoleKey difficulty)
        {
            switch (difficulty)
            {
                case ConsoleKey.D1:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("ROUND ");
                    Console.ForegroundColor = foreground;
                    Console.Write($"{round}");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine();
                    Printer.DoubleDash();
                    break;
                case ConsoleKey.D2:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("ROUND ");
                    Console.ForegroundColor = foreground;
                    Console.Write($"{round}");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine();
                    Printer.DoubleDash();
                    break;
                case ConsoleKey.D3:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("ROUND ");
                    Console.ForegroundColor = foreground;
                    Console.Write($"{round}");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine();
                    Printer.DoubleDash();
                    break;
                default:
                    return;
            }
            Console.ForegroundColor = foreground;
            Console.WriteLine();
        }
        public static void ChooseDifficulty(string playerName)
        {
            Console.WriteLine($"Hello {playerName}! Now Choose your enemy:");
            Console.Write("1. Goblin - ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Easy");
            Console.WriteLine();
            Console.ForegroundColor = foreground;
            Console.Write("2. Orcish Warrior - ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Medium");
            Console.WriteLine();
            Console.ForegroundColor = foreground;
            Console.Write("3. Mountain Troll - ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Hard");
            Console.ForegroundColor = foreground;
            Console.WriteLine();
        }
        public static void ChooseAction()
        {
            Console.WriteLine("Choose Your Action:");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("1. Attack");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("2. Parry");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("3. Kick");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("4. Use Ability");
            Console.ForegroundColor = foreground;
            Printer.Dash();

        }
        public static void ChooseActionNoMana()
        {
            Console.WriteLine("Choose Your Action:");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("1. Attack");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("2. Parry");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("3. Kick");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("4. Use Ability");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("No Mana Left...");
            Console.ForegroundColor = foreground;
            Printer.Dash();

        }
        public static void ChooseAbility()
        {
            Console.WriteLine("Choose Ability:");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("1. Flame Sword Attack - Double Damage Attack");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("2. Heal - Heal For 4 HP");
            Console.ForegroundColor = foreground;
            Printer.Dash();

        }
        public static void UnitStats(Unit unit)
        {
            Console.WriteLine($"{unit.Name}:");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write($"HP - ");
            Console.ForegroundColor = foreground;
            Console.Write($"{unit.CurrentHP}");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write($"Shield - ");
            Console.ForegroundColor = foreground;
            Console.Write($"{unit.CurrentShield}");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"Damage - ");
            Console.ForegroundColor = foreground;
            Console.Write($"{unit.Damage} ");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write($"Mana - ");
            Console.ForegroundColor = foreground;
            Console.Write($"{unit.Mana} ");
            Console.WriteLine();
            Console.WriteLine();
        }
        public static void UnitTryAttack(Unit unit)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{unit.Name} tries to attack for ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"{unit.Damage} ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("damage.");
            Console.ForegroundColor = foreground;
            Console.WriteLine();
            Console.WriteLine();
        }
        public static void UnitAttack(Unit attUnit, Unit deffUnit)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{attUnit.Name} attacks {deffUnit.Name} for ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"{attUnit.Damage} ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("damage.");
            Console.ForegroundColor = foreground;
            Console.WriteLine();
            Console.WriteLine();
        }
        public static void UnitTryParry(Unit unit)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{unit.Name} tries to parry the attack.");
            Console.ForegroundColor = foreground;
            Console.WriteLine();
        }
        public static void UnitParry(Unit unit)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{unit.Name} successfully parries the attack and reacharges his shield.");
            Console.ForegroundColor = foreground;
            Console.WriteLine();
        }
        public static void UnitTryKick(Unit unit)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"{unit.Name} tries to kick the target.");
            Console.ForegroundColor = foreground;
            Console.WriteLine();
        }
        public static void UnitKick(Unit attUnit, Unit deffUnit)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write($"{attUnit.Name} kicks {deffUnit.Name} and he loses ");
            Console.ForegroundColor = foreground;
            Console.Write("1 ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("HP.");
            Console.ForegroundColor = foreground;
            Console.WriteLine();
            Console.WriteLine();
        }
        public static void UnitBreak(Unit attUnit, Unit deffUnit)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"{attUnit.Name} successfully stuns {deffUnit.Name}.");
            Console.ForegroundColor = foreground;
            Console.WriteLine();
        }
        public static void UnitTryDDAttack(Unit unit)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{unit.Name} lights his sword on fire and tries to attack for ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{unit.Damage*2} ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Damage!");
            Console.ForegroundColor = foreground;
            Console.WriteLine();
        }
        public static void UnitDDAttack(Unit attUnit, Unit deffUnit)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"{attUnit.Name} attacks {deffUnit.Name} for ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write($"{attUnit.Damage*2} ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("damage.");
            Console.ForegroundColor = foreground;
            Console.WriteLine();
            Console.WriteLine();
        }
        public static void UnitHeal(Unit unit)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"{unit.Name} heals for ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("4 ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("HP");
            Console.ForegroundColor = foreground;
            Console.WriteLine();
        }
        public static void UnitStunned(Unit unit)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{unit.Name} is stunned.");
            Console.ForegroundColor = foreground;
            Console.WriteLine();
        }
        public static void Nothing()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Nothing Happened");
            Console.ForegroundColor = foreground;
            Console.WriteLine();
        }
        public static void Fall()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Both units fall on the ground and recieve ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("2 ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("damage");
            Console.ForegroundColor = foreground;
            Console.WriteLine();
        }
        public static void NoInput()
        {
            Console.WriteLine("Invalid Input... ");
            Console.WriteLine();
        }
        public static void InvalidOption()
        {
            Console.WriteLine("Invalid Option...");
            Console.WriteLine();
        }
        public static void CantUseAbilities()
        {
            Console.WriteLine("No Mana, Cant use abilities...");
            Console.WriteLine();
        }
        public static void Dash()
        {
            Console.WriteLine("----------------------");
        }
        public static void DoubleDash()
        {
            Console.WriteLine("======================");
        }
        public static void YouDied()
        {
            Console.WriteLine(@"

██╗   ██╗ ██████╗ ██╗   ██╗    ██████╗ ██╗███████╗██████╗          
╚██╗ ██╔╝██╔═══██╗██║   ██║    ██╔══██╗██║██╔════╝██╔══██╗         
 ╚████╔╝ ██║   ██║██║   ██║    ██║  ██║██║█████╗  ██║  ██║         
  ╚██╔╝  ██║   ██║██║   ██║    ██║  ██║██║██╔══╝  ██║  ██║         
   ██║   ╚██████╔╝╚██████╔╝    ██████╔╝██║███████╗██████╔╝██╗██╗██╗
   ╚═╝    ╚═════╝  ╚═════╝     ╚═════╝ ╚═╝╚══════╝╚═════╝ ╚═╝╚═╝╚═╝
                                                                   
");
        }
        public static void YouWin()
        {
            Console.WriteLine(@"
██╗   ██╗ ██████╗ ██╗   ██╗    ██╗    ██╗██╗███╗   ██╗██╗
╚██╗ ██╔╝██╔═══██╗██║   ██║    ██║    ██║██║████╗  ██║██║
 ╚████╔╝ ██║   ██║██║   ██║    ██║ █╗ ██║██║██╔██╗ ██║██║
  ╚██╔╝  ██║   ██║██║   ██║    ██║███╗██║██║██║╚██╗██║╚═╝
   ██║   ╚██████╔╝╚██████╔╝    ╚███╔███╔╝██║██║ ╚████║██╗
   ╚═╝    ╚═════╝  ╚═════╝      ╚══╝╚══╝ ╚═╝╚═╝  ╚═══╝╚═╝
                                                         
");
        }
        public static void ItsaTie()
        {
            Console.WriteLine(@"
██╗████████╗███████╗     █████╗     ████████╗██╗███████╗██╗
██║╚══██╔══╝██╔════╝    ██╔══██╗    ╚══██╔══╝██║██╔════╝██║
██║   ██║   ███████╗    ███████║       ██║   ██║█████╗  ██║
██║   ██║   ╚════██║    ██╔══██║       ██║   ██║██╔══╝  ╚═╝
██║   ██║   ███████║    ██║  ██║       ██║   ██║███████╗██╗
╚═╝   ╚═╝   ╚══════╝    ╚═╝  ╚═╝       ╚═╝   ╚═╝╚══════╝╚═╝
                                                           
");
        }
    }
}