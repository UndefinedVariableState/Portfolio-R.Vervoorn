namespace Pokemon;

public class Bulbasaur : Pokemon
{
    public Bulbasaur(string name, Pokemon.Types strength = Pokemon.Types.Grass, Pokemon.Types weakness = Pokemon.Types.Fire) : base(name, strength, weakness) { }

    public override void UseBattleCry(string pokemonName)
    {
        Console.Write(pokemonName + " uses it's battle cry: \"");
        if (pokemonName != "") { Console.Write(pokemonName + "!"); }
        else { Console.Write("Bulbasaur!"); }
        Console.WriteLine("\"");
    }
}
