namespace KapanGame
{
    enum ActionType
    {
        Nothing = 0,
        Attack = 1,
        Parry = 2,
        Kick = 3,
        Ability = 4,
        NoInput = 5
    }
    enum AiType
    {
        AiAction,
        AiAbility,
    }
    class Combat
    {
        public int Round;
        public ConsoleKey Difficulty { get; set; }
        public Unit Player { get; private set; }
        public Unit Enemy { get; private set; }
        public Abilities PlayerAbilities { get; private set; }
        public Abilities EnemyAbilities { get; private set; }
        public ActionType PlayerAction { get; private set; } = ActionType.NoInput;
        public ActionType EnemyAction { get; private set; } = ActionType.NoInput;
        public AbilityType PlayerAbility { get; private set; } = AbilityType.NoInput;  
        public AbilityType EnemyAbility { get; private set; } = AbilityType.NoInput;  
        public Combat(string playerName, ConsoleKey difficulty)
        {
            Round = 1;
            Difficulty = difficulty;
            Player = new Unit(playerName, 10, 4, 3, 3);
            switch (difficulty)
            {
                case ConsoleKey.D1:
                    Enemy = new Unit("Goblin", 15, 3, 3, 3);
                    break;
                case ConsoleKey.D2:
                    Enemy = new Unit("Orcish Warrior", 20, 4, 4, 4);
                    break;
                case ConsoleKey.D3:
                    Enemy = new Unit("Mountain Troll", 25, 5, 4, 4);
                    break;
                default:
                    Console.WriteLine("no option");
                    Environment.Exit(0);
                    return; 
            }
            PlayerAbilities = new Abilities(Player);
            EnemyAbilities = new Abilities(Enemy);
        }
        public void CombatTurn()
        {
            while (!(Player.IsDead() || Enemy.IsDead()))
            {
                Console.SetCursorPosition(0, 0);
                Printer.Round(Round, Difficulty);
                Printer.UnitStats(Player);
                Printer.UnitStats(Enemy);
                Printer.Dash();
                PlayerAction = PlayersTurn();
                EnemyAction = EnemysTurn();
                Printer.Dash();
                Outcome(PlayerAction, EnemyAction);
                StatusReset();
                Thread.Sleep(3000);
                Console.Clear();
                Round++;
            }
        }
        public ActionType PlayersTurn()
        {
            if (Player.Stunned == true)
            {
                Printer.UnitStunned(Player);
                Player.Stunned = false;
                return ActionType.Nothing;
            }
            return PlayerChooseAction();
        }
        public ActionType EnemysTurn()
        {
            if (Enemy.Stunned == true)
            {
                Printer.UnitStunned(Enemy);
                Enemy.Stunned = false;
                return ActionType.Nothing;
            }
            if (PlayerAction == ActionType.Nothing)
            {
                Player.TakeDamage(Enemy.Attack());
                Printer.UnitAttack(Enemy, Player);
                return ActionType.Attack;
            }
            Thread.Sleep(1500);
            return EnemyChooseAction(EnemyAI(AiType.AiAction));
        }
        public void CombatResults(Sounds sounds)
        {
            if (Player.IsDead() && Enemy.IsDead())
            {
                sounds.DieSFX.Play();
                Printer.ItsaTie();
            }
            else if (Player.IsDead())
            {
                sounds.DieSFX.Play();
                Printer.YouDied();
            }
            else
            {
                sounds.WinSFX.Play();
                Printer.YouWin();
            }
                Console.WriteLine("Press any key to start over...");
            Console.ReadKey();
        }
        public void StatusReset()
        {
            Player.Parring = false;
            Enemy.Parring = false;

        }
        public ActionType PlayerChooseAction()
        {
            if (Player.Mana == 0)
            {
                Printer.ChooseActionNoMana();
                ConsoleKey input = Console.ReadKey(true).Key;
                Console.WriteLine();
                switch (input)
                {
                    case ConsoleKey.D1:
                        Printer.UnitTryAttack(Player);
                        return ActionType.Attack;
                    case ConsoleKey.D2:
                        Player.Parry();
                        Printer.UnitTryParry(Player);
                        return ActionType.Parry;
                    case ConsoleKey.D3:
                        Printer.UnitTryKick(Player);
                        return ActionType.Kick;
                    case ConsoleKey.D4:
                        Printer.CantUseAbilities();
                        return ActionType.NoInput;
                    default:
                        Printer.NoInput();
                        return ActionType.NoInput;
                }
            }
            else
            {
                Printer.ChooseAction();
                ConsoleKey input = Console.ReadKey(true).Key;
                Console.WriteLine();
                switch (input)
                {

                    case ConsoleKey.D1:
                        Printer.UnitTryAttack(Player);
                        return ActionType.Attack;
                    case ConsoleKey.D2:
                        Player.Parry();
                        Printer.UnitTryParry(Player);
                        return ActionType.Parry;
                    case ConsoleKey.D3:
                        Printer.UnitTryKick(Player);
                        return ActionType.Kick;
                    case ConsoleKey.D4:
                        PlayerAbility = PlayerAbilities.PlayerChooseAbility(Player);
                        return ActionType.Ability;
                    default:
                        Printer.NoInput();
                        return ActionType.NoInput;
                }
            }
            
        }
        public ActionType EnemyChooseAction(int input)
        {
            if (PlayerAction == ActionType.NoInput)
            {
                return ActionType.NoInput;
            }
            else if (Enemy.Mana == 0)
            {
                switch (input)
                {
                    case 1:
                        Printer.UnitTryAttack(Enemy);
                        return ActionType.Attack;
                    case 2:
                        Enemy.Parry();
                        Printer.UnitTryParry(Enemy);
                        return ActionType.Parry;
                    case 3:
                        Printer.UnitTryKick(Enemy);
                        return ActionType.Kick;
                    case 4:
                        int rand = Random.Shared.Next(1, 4);
                        switch (rand)
                        {
                            case 1:
                                Printer.UnitTryAttack(Enemy);
                                return ActionType.Attack;
                            case 2:
                                Enemy.Parry();
                                Printer.UnitTryParry(Enemy);
                                return ActionType.Parry;
                            case 3:
                                Printer.UnitTryKick(Enemy);
                                return ActionType.Kick;
                            default:
                                return ActionType.Nothing;
                        }
                    default:
                        return ActionType.Nothing;
                }
            }
            else
            {
                switch (input)
                {
                    case 1:
                        Printer.UnitTryAttack(Enemy);
                        return ActionType.Attack;
                    case 2:
                        Enemy.Parry();
                        Printer.UnitTryParry(Enemy);
                        return ActionType.Parry;
                    case 3:
                        Printer.UnitTryKick(Enemy);
                        return ActionType.Kick;
                    case 4:
                        EnemyAbility = EnemyAbilities.EnemyChooseAbility(Enemy, EnemyAI(AiType.AiAbility));
                        return ActionType.Ability;
                    default:
                        return ActionType.Nothing;
                }
            }
            
        }
        public int EnemyAI(AiType type)
        {
            switch (type)
            {
                case AiType.AiAction:
                    return Random.Shared.Next(1, 5);
                case AiType.AiAbility:
                    return Random.Shared.Next(1, 3);
                default:
                    return 0; 
            }
        }
        public void Outcome(ActionType playerAction, ActionType enemyAction)
        {
            if (playerAction == ActionType.Attack)
            {
                if (enemyAction == ActionType.Attack)
                {
                    Enemy.TakeDamage(Player.Attack());
                    Player.TakeDamage(Enemy.Attack());
                    Printer.UnitAttack(Player, Enemy);
                    Printer.UnitAttack(Enemy, Player);
                }
                else if (enemyAction == ActionType.Parry)
                {
                    Enemy.CurrentShield = Enemy.MaxShield;
                    Printer.UnitParry(Enemy);
                }
                else if (enemyAction == ActionType.Kick)
                {
                    Enemy.TakeDamage(Player.Attack());
                    Player.GetKicked();
                    Printer.UnitAttack(Player, Enemy);
                    Printer.UnitKick(Enemy, Player);
                }
                else if (enemyAction == ActionType.Ability)
                {
                    if (EnemyAbility == AbilityType.DD)
                    {
                        Enemy.TakeDamage(Player.Attack());
                        Player.TakeDamage(Enemy.Attack()*2);
                        Printer.UnitAttack(Player, Enemy);
                        Printer.UnitDDAttack(Enemy, Player);
                    }
                    else if (EnemyAbility == AbilityType.Heal)
                    {
                        Enemy.Heal(4);
                        Enemy.TakeDamage(Player.Attack());
                        Printer.UnitAttack(Player, Enemy);
                        Printer.UnitHeal(Enemy);
                    }
                }
                else if (enemyAction == ActionType.Nothing)
                {
                    Enemy.TakeDamage(Player.Attack());
                    Printer.UnitAttack(Player, Enemy);
                }
            }
            if (playerAction == ActionType.Parry)
            {
                if (enemyAction == ActionType.Attack)
                {
                    Player.CurrentShield = Player.MaxShield;
                    Printer.UnitParry(Player);
                }
                else if (enemyAction == ActionType.Parry)
                {
                    Printer.Nothing();
                }
                else if (enemyAction == ActionType.Kick)
                {
                    Printer.UnitBreak(Enemy, Player);
                    Player.Stunned = true;
                }
                else if (enemyAction == ActionType.Ability)
                {
                    if (EnemyAbility == AbilityType.DD)
                    {
                        Player.CurrentShield = Player.MaxShield;
                        Printer.UnitParry(Player);
                    }
                    else if (EnemyAbility == AbilityType.Heal)
                    {
                        Enemy.Heal(4);
                        Printer.UnitHeal(Enemy);
                    }
                }
                else if (enemyAction == ActionType.Nothing)
                {
                    Printer.Nothing();
                }
            }
            if (playerAction == ActionType.Kick)
            {
                if (enemyAction == ActionType.Attack)
                {
                    Player.TakeDamage(Enemy.Attack());
                    Enemy.GetKicked();
                    Printer.UnitAttack(Enemy, Player);
                    Printer.UnitKick(Player,Enemy);
                }
                else if (enemyAction == ActionType.Parry)
                {
                    Printer.UnitBreak(Player, Enemy);
                    Enemy.Stunned = true;
                }
                else if (enemyAction == ActionType.Kick)
                {
                    Printer.Fall();
                    Player.GetKickedFall();
                    Enemy.GetKickedFall();
                }
                else if (enemyAction == ActionType.Ability)
                {
                    if (EnemyAbility == AbilityType.DD)
                    {
                        Player.TakeDamage(Enemy.Attack() * 2);
                        Enemy.GetKicked();
                        Printer.UnitKick(Player,Enemy);
                        Printer.UnitDDAttack(Enemy, Player);
                    }
                    else if (EnemyAbility == AbilityType.Heal)
                    {
                        Enemy.Heal(4);
                        Enemy.GetKicked();
                        Printer.UnitKick(Player, Enemy);
                        Printer.UnitHeal(Enemy);
                    }
                }
                else if (enemyAction == ActionType.Nothing)
                {
                    Printer.Nothing();
                }
            }
            if (playerAction == ActionType.Ability)
            {
                if (PlayerAbility == AbilityType.DD)
                {
                    if (enemyAction == ActionType.Attack)
                    {
                        Enemy.TakeDamage(Player.Attack()*2);
                        Player.TakeDamage(Enemy.Attack());
                        Printer.UnitDDAttack(Player, Enemy);
                        Printer.UnitAttack(Enemy, Player);
                    }
                    else if (enemyAction == ActionType.Parry)
                    {
                        Enemy.CurrentShield = Enemy.MaxShield;
                        Printer.UnitParry(Enemy);
                    }
                    else if (enemyAction == ActionType.Kick)
                    {
                        Player.GetKicked();
                        Enemy.TakeDamage(Player.Attack()*2);
                        Printer.UnitDDAttack(Player, Enemy);
                        Printer.UnitKick(Enemy,Player);
                    }
                    else if (enemyAction == ActionType.Ability)
                    {
                        if (EnemyAbility == AbilityType.DD)
                        {
                            Enemy.TakeDamage(Player.Attack() * 2);
                            Player.TakeDamage(Enemy.Attack() * 2);
                            Printer.UnitDDAttack(Player, Enemy);
                            Printer.UnitDDAttack(Enemy, Player);
                        }
                        else if (EnemyAbility == AbilityType.Heal)
                        {
                            Enemy.Heal(4);
                            Enemy.TakeDamage(Player.Attack() * 2);
                            Printer.UnitDDAttack(Player, Enemy);
                            Printer.UnitHeal(Enemy);
                        }
                    }
                    else if (enemyAction == ActionType.Nothing)
                    {
                        Enemy.TakeDamage(Player.Attack() * 2);
                        Printer.UnitDDAttack(Player, Enemy);
                    }
                }
                else if (PlayerAbility == AbilityType.Heal)
                {
                    if (enemyAction == ActionType.Attack)
                    {
                        Player.Heal(4);
                        Player.TakeDamage(Enemy.Attack());
                        Printer.UnitHeal(Player); 
                        Printer.UnitAttack(Enemy, Player);
                    }
                    else if (enemyAction == ActionType.Parry)
                    {
                        Player.Heal(4);
                        Printer.UnitHeal(Player); 
                    }
                    else if (enemyAction == ActionType.Kick)
                    {
                        Player.Heal(4);
                        Player.GetKicked();
                        Printer.UnitHeal(Player);
                        Printer.UnitKick(Enemy, Player);
                    }
                    else if (enemyAction == ActionType.Ability)
                    {
                        if (EnemyAbility == AbilityType.DD)
                        {
                            Player.Heal(4);
                            Player.TakeDamage(Enemy.Attack() * 2);
                            Printer.UnitHeal(Player);
                            Printer.UnitDDAttack(Enemy, Player);
                        }
                        else if (EnemyAbility == AbilityType.Heal)
                        {
                            Player.Heal(4);
                            Enemy.Heal(4);
                            Printer.UnitHeal(Player);
                            Printer.UnitHeal(Enemy);
                        }
                    }
                    else if (enemyAction == ActionType.Nothing)
                    {
                        Player.Heal(4);
                        Printer.UnitHeal(Player);
                    }
                }
            }
            if (playerAction == ActionType.NoInput)
            {
                Printer.InvalidOption();
            }
        }
    }

}