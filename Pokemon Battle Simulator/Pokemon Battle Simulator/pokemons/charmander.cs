namespace Pokemon;

public class Charmander : Pokemon
{
    public Charmander(string name, Pokemon.Types strength = Pokemon.Types.Fire, Pokemon.Types weakness = Pokemon.Types.Water) : base(name, strength, weakness) { }

    public override void UseBattleCry(string pokemonName)
    {
        Console.Write(pokemonName + " uses it's battle cry: \"");
        if (pokemonName != "") { Console.Write(pokemonName + "!"); }
        else { Console.Write("Charmander!"); }
        Console.WriteLine("\"");
    }
}
