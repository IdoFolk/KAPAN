using System.Media;

namespace KapanGame
{
    class Game
    {
        bool _invalid = true;
        Sounds Sounds = new Sounds();
        public void Start()
        {
            Sounds.Load();
            Sounds.BackgroundMusic.PlayLooping();
            Printer.Welcome();
            Printer.Kapan();
            string playerName = ChoosePlayerName();
            Console.SetCursorPosition(0,16);
            ConsoleKey Difficulty = ChooseDifficulty(playerName);
            Combat fight = new Combat(playerName, Difficulty);
            Console.Clear();
            fight.CombatTurn();
            Sounds.BackgroundMusic.Stop();
            fight.CombatResults(Sounds);
            Console.Clear();
        }
        public static string ChoosePlayerName()
        {
            string defaultPlayerName = "Player";
            Console.WriteLine("Name your player:");
            string input = Console.ReadLine();
            if (input != null)
                return input;
            else
                return defaultPlayerName;
        }
        public ConsoleKey ChooseDifficulty(string playerName)
        {
            while (_invalid)
            {
                Printer.ChooseDifficulty(playerName);
                ConsoleKey input = Console.ReadKey(true).Key;
                switch (input)
                {
                    case ConsoleKey.D1:
                        _invalid = false;
                        return ConsoleKey.D1;
                    case ConsoleKey.D2:
                        _invalid = false;
                        return ConsoleKey.D2;
                    case ConsoleKey.D3:
                        _invalid = false;
                        return ConsoleKey.D3;
                    default:
                        Printer.NoInput();
                        _invalid = true;
                        break;
                }
            }
            return ConsoleKey.Escape;
        }
    }
}