namespace Trainer;

using Pokemon;

public sealed class Pokeball
{
    private readonly Pokemon pokemon;
    private bool isEmpty;


    public Pokeball(Pokemon pokemon = null)
    {
        this.pokemon = pokemon;
        this.isEmpty = pokemon == null;
    }


    public static Pokemon getPokemon(Pokeball curBall)
    {
        return curBall.pokemon;
    }
}