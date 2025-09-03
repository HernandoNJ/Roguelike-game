var randomNumber = new Random();
var diceNum = randomNumber.Next(1, 7);
Console.WriteLine(diceNum);
Console.ReadKey();

public class Dice
{
    private Random _random;

    public Dice(Random random)
    {
        _random = random;
    }
    
    public int Roll()
    {
        return _random.Next(1, 7);
    }
}