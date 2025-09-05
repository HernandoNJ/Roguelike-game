public class Dice
{
    private Random _random;
    private int _diceSides = 6;

    public Dice(Random random)
    {
        _random = random;
    }

    public int Roll() => _random.Next(1, _diceSides + 1);
}