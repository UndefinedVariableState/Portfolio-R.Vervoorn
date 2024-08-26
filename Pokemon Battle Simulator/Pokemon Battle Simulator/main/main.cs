namespace Main;

using Pokemon;
using Trainer;
using Fight;

public class Program
{
    static void Main(string[] args)
    {
        Console.Write("Give the first trainer a name: ");
        Trainer firstTrainer = new Trainer(Console.ReadLine());
        Console.Write("Give the second trainer a name: ");
        Trainer secondTrainer = new Trainer(Console.ReadLine());
        Arena.enterArena(firstTrainer, secondTrainer);
    }


    public static string FirstCharToUpper(string input)
    {
        switch (input)
        {
            case null: throw new ArgumentNullException(nameof(input));
            case "": throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));
            default: return input[0].ToString().ToUpper() + input.Substring(1);
        }
    }


    public static int randomNumber(int min, int max) 
    {
        Random rnd = new Random();
        int chosenNumber = rnd.Next(min, max);
        return chosenNumber;
    }
}