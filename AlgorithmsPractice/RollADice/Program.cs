var dice = new Dice(new Random());
Console.WriteLine(dice.Roll());
Console.ReadKey();

public class Dice
{
    private Random _random;

    public Dice(Random random) => _random = random;

    public int Roll() => _random.Next(1, 7);
}