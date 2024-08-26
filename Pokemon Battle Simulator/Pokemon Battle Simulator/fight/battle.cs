namespace Fight;

using Main;
using Pokemon;
using Trainer;

public class Battle
{
    private Trainer trainer1;
    private List<Pokeball> trainer1belt;
    private Trainer trainer2;
    private List<Pokeball> trainer2belt;
    private Dictionary<Trainer, Pokeball?> fieldHolders;

    public Battle(Trainer trainer1, Trainer trainer2)
    {
        this.trainer1 = trainer1;
        this.trainer1belt = trainer1.deepCopyBelt(trainer1.Belt);
        this.trainer2 = trainer2;
        this.trainer2belt = trainer2.deepCopyBelt(trainer2.Belt);
        this.fieldHolders = new Dictionary<Trainer, Pokeball?>();
        fieldHolders.Add(trainer1, null);
        fieldHolders.Add(trainer2, null);
    }

    public void startBattle()
    {
        Dictionary<Trainer, List<Pokeball>> participants = new Dictionary<Trainer, List<Pokeball>>();
        participants.Add(trainer1, trainer1belt);
        participants.Add(trainer2, trainer2belt);

        while (trainer1belt.Count > 0 && trainer2belt.Count > 0)
        {
            Arena.addRound();
            Console.WriteLine("---------------------------------------------------------");
            foreach (KeyValuePair<Trainer, List<Pokeball>> entry in participants)
            {
                Trainer curTrainer = entry.Key;
                List<Pokeball> curBelt = entry.Value;
                if (fieldHolders[curTrainer] == null)
                {
                    fieldHolders[curTrainer] = curBelt[Program.randomNumber(0, curBelt.Count)];
                    Pokemon curPokemon = Pokeball.getPokemon(fieldHolders[curTrainer]);
                    curTrainer.throwPokeball(curTrainer.Name, curPokemon);
                    curPokemon.UseBattleCry(curPokemon.Name);
                }
            }
            Console.WriteLine($"Round {Arena.Round}: \n ");
            Pokemon? winner = fightRound(Pokeball.getPokemon(fieldHolders[trainer1]), Pokeball.getPokemon(fieldHolders[trainer2]), Arena.Round);
            if (winner == null)
            {
                Console.WriteLine("Winner: None");
                trainer1belt.Remove(fieldHolders[trainer1]);
                trainer2belt.Remove(fieldHolders[trainer2]);
                fieldHolders[trainer1] = null;
                fieldHolders[trainer2] = null;
            }
            else if (winner == Pokeball.getPokemon(fieldHolders[trainer2]))
            {
                Console.WriteLine("Winner: " + winner.Name);
                trainer1.returnToPokeball(trainer1.Name, Pokeball.getPokemon(fieldHolders[trainer1]));
                trainer1belt.Remove(fieldHolders[trainer1]);
                fieldHolders[trainer1] = null;
            }
            else if (winner == Pokeball.getPokemon(fieldHolders[trainer1]))
            {
                Console.WriteLine("Winner: " + winner.Name);
                trainer2.returnToPokeball(trainer2.Name, Pokeball.getPokemon(fieldHolders[trainer2]));
                trainer2belt.Remove(fieldHolders[trainer2]);
                fieldHolders[trainer2] = null;
            }
            Console.ReadLine();
        }
        Console.WriteLine("---------------------------------------------------------");
        if (trainer1belt.Count == trainer2belt.Count) { Console.WriteLine("THE BATTLE IS A DRAW!!!"); }
        else if (trainer1belt.Count == 0) { Console.WriteLine($"{trainer2.Name} WON THE BATTLE!!!"); }
        else if (trainer2belt.Count == 0) { Console.WriteLine($"{trainer1.Name} WON THE BATTLE!!!"); }
        Console.WriteLine("---------------------------------------------------------");
    }


    public static Pokemon? fightRound(Pokemon pokemon1, Pokemon pokemon2, int curRound)
    {
        Dictionary<Pokemon, Pokemon.Types> strengths = new Dictionary<Pokemon, Pokemon.Types>(); 
        strengths.Add(pokemon1, Pokemon.getStrength(pokemon1));
        strengths.Add(pokemon2, Pokemon.getStrength(pokemon2));
        if (strengths[pokemon1] == strengths[pokemon2])
        {
            Console.WriteLine($"it's a draw! (round {curRound.ToString()})");
            return null;
        }
        else if ((strengths[pokemon1] == Pokemon.Types.Fire && strengths[pokemon2] == Pokemon.Types.Grass) ||
                (strengths[pokemon1] == Pokemon.Types.Grass && strengths[pokemon2] == Pokemon.Types.Water) ||
                (strengths[pokemon1] == Pokemon.Types.Water && strengths[pokemon2] == Pokemon.Types.Fire))
        {
            Console.WriteLine($"{pokemon1.Name} wins! (round {curRound.ToString()})");
            return pokemon1;
        }
        else
        {
            Console.WriteLine($"{pokemon2.Name} wins! (round {curRound.ToString()})");
            return pokemon2;
        }
    }
}