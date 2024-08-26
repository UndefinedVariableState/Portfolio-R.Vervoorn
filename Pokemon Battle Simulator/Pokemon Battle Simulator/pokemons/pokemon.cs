namespace Pokemon;

public abstract class Pokemon
{
    public enum Types
    {
        Fire,
        Grass,
        Water
    }

    private readonly string name;
    protected Types Strength { get; }
    protected Types Weakness { get; }

    public string Name { get { return name; } }

    public Pokemon(string name, Types strength, Types weakness)
    {
        this.name = name;
        Strength = strength;
        Weakness = weakness;
    }

    public abstract void UseBattleCry(string pokemonName);

    public static Types getWeakness(Pokemon pokeObject) { return pokeObject.Weakness; }

    public static Types getStrength(Pokemon pokeObject) { return pokeObject.Strength; }
}