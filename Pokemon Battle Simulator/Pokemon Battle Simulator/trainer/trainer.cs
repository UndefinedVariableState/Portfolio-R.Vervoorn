namespace Trainer;

using Main;
using Pokemon;

public class Trainer
{
    private readonly string name;
    private readonly List<Pokeball> belt;

    public string Name { get { return name; } }
    public List<Pokeball> Belt { get { return belt; } }


    public Trainer(string name)
    {
        const int beltLength = 6;
        this.name = Program.FirstCharToUpper(name.ToLower());
        List<Pokeball> thisBelt = createBelt();
        if (thisBelt.Count <= beltLength)
        {
            this.belt = thisBelt;
        }
        else
        {
            throw new Exception();
        }
    }


    private List<Pokeball> createBelt()
    {
        List<Pokeball> belt = new List<Pokeball>();

        for (int index = 1; index < 3; index++)
        {
            Pokeball charBall = new Pokeball(new Charmander("Charmander"));
            Pokeball sqBall = new Pokeball(new Squirtle("Squirtle"));
            Pokeball bulbBall = new Pokeball(new Bulbasaur("Bulbasaur"));
            belt.Add(charBall);
            belt.Add(sqBall);
            belt.Add(bulbBall);
        }
        return belt;
    }


    public static int beltCount(Trainer curTrainer)
    {
        return curTrainer.belt.Count;
    }


    public void throwPokeball(string trainerName, Pokemon pokemonObj)
    {
        if (pokemonObj != null) { Console.WriteLine(trainerName + " releases " + pokemonObj.Name + " out of it's ball!"); }
        else { Console.WriteLine(trainerName + " throws an empty ball..."); }
    }


    public void returnToPokeball(string trainerName, Pokemon pokemonObj)
    {
        if (pokemonObj != null) { Console.WriteLine(trainerName + " returns " + pokemonObj.Name + " back to it's pokeball!"); }
        else { Console.WriteLine(trainerName + " returns the empty pokeball!"); }
    }


    public List<Pokeball> deepCopyBelt(List<Pokeball> trainerBelt)
    {
        List<Pokeball> deepCopyBelt = new List<Pokeball>(trainerBelt.Count);
        foreach (Pokeball pokeball in trainerBelt)
        {
            Pokeball duplicatePokeball = new Pokeball(Pokeball.getPokemon(pokeball));
            deepCopyBelt.Add(duplicatePokeball);
        }
        return deepCopyBelt;
    }
}