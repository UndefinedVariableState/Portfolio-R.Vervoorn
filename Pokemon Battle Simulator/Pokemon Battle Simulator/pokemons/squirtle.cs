namespace Pokemon;

public class Squirtle : Pokemon
{
    public Squirtle(string name, Pokemon.Types strength = Pokemon.Types.Water, Pokemon.Types weakness = Pokemon.Types.Grass) : base(name, strength, weakness) { }

    public override void UseBattleCry(string pokemonName)
    {
        Console.Write(pokemonName + " uses it's battle cry: \"");
        if (pokemonName != "") { Console.Write(pokemonName + "!"); }
        else { Console.Write("Squirtle!"); }
        Console.WriteLine("\"");
    }
}
