var triesCount = 0;

var dice = new Dice(new Random());
var diceNumber = dice.Roll();
Console.WriteLine("The dice number is: " + diceNumber); // only for testing

dice.HandleUserInput(diceNumber, ref triesCount);

Console.WriteLine("tries count is: " + triesCount); // only for testing
Console.WriteLine("Press a key to exit");

Console.ReadKey();

public class Dice
{
    private Random _random;

    public Dice(Random random) => _random = random;

    public int Roll() => _random.Next(1, 7);
    
    public void HandleUserInput(int i, ref int triesCountArg)
    {
        do
        {
            Console.WriteLine("Enter a number");
            var newInput = Console.ReadLine();
            var userInput = Convert.ToInt32(newInput);
            triesCountArg++;

            if (userInput == i)
            {
                Console.WriteLine("You win!");
                return;
            }
        
            if (triesCountArg < 3)
            {
                Console.WriteLine("Try again!");
            }
            else if (triesCountArg == 3)
            {
                Console.WriteLine("You lose!");
                break;
            }
        } while (triesCountArg < 3);
    }
}