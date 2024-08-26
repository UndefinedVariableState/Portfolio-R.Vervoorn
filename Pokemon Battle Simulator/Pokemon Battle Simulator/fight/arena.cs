namespace Fight;

using Trainer;

public static class Arena
{
    private static int round = 0;
    private static int battles = 0;

    public static int Round { get { return round; } }
    public static int Battles { get { return battles; } }

    public static void enterArena(Trainer firstTrainer, Trainer secondTrainer)
    {
        bool exitProgram = false;
        while (!exitProgram)
        {
            Battle battle = new Battle(firstTrainer, secondTrainer);
            battle.startBattle();
            Arena.addBattle();
            Console.WriteLine($"Rounds fought: {Arena.Round}");
            Console.WriteLine($"Battles fought: {Arena.Battles}");
            Arena.removeRound();
            bool anwsered = false;
            while (!anwsered)
            {
                Console.Write("\nDo you want to battle again? (Y/N): ");
                switch (Console.ReadLine())
                {
                    case "Y":
                        exitProgram = false;
                        anwsered = true;
                        break;
                    case "N":
                        exitProgram = true;
                        anwsered = true;
                        break;
                    default:
                        Console.WriteLine("Try again...");
                        break;
                }
            }
        }
    }

    public static void addRound() => round++;
    public static void removeRound() => round = 0;
    public static void addBattle() => battles++;
}