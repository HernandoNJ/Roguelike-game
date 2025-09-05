var triesCount = 0;
const int maxTries = 3;

var dice = new Dice(new Random(), 6);
var diceNumber = dice.Roll();
Console.WriteLine("The dice number is: " + diceNumber); // only for testing

dice.HandleUserInput(diceNumber, ref triesCount, maxTries);

Console.WriteLine("Press a key to exit");
Console.ReadKey();

public class Dice
{
    private Random _random;
    private int _maxDiceNumber;

    public Dice(Random random, int maxDiceNumber)
    {
        _random = random;
        _maxDiceNumber = maxDiceNumber;
    }

    public int Roll() => _random.Next(1, _maxDiceNumber + 1);

    public void HandleUserInput(int diceNumberArg, ref int triesCountArg, int maxTriesArg)
    {
        while (triesCountArg < maxTriesArg)
        {
            Console.WriteLine("Enter a number");
            var newInput = Console.ReadLine();
            var userInput = Convert.ToInt32(newInput);
            triesCountArg++;

            if (userInput == diceNumberArg)
            {
                Console.WriteLine("You win!");
                return;
            }

            if (userInput != diceNumberArg && triesCountArg < maxTriesArg - 1)
            {
                Console.WriteLine("Try again!");
            }
        }

        Console.WriteLine("You lose!");
    }
}