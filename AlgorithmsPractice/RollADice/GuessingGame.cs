namespace RollADice;

public enum GameResult { Victory, Loss }

// Responsible for the guessing the number that was rolled on a dice
public class GuessingGame
{
    // It requires a dice object to be rolled when the game starts.
    private readonly Dice _dice;

    private const int _maxTries = 3;

    // Constructor with dice dependency
    public GuessingGame(Dice dice)
    {
        _dice = dice;
    }

    public GameResult Play()
    {
        // Roll the dice and store the result in a variable.
        var diceNumber = _dice.Roll();

        // Initial message
        Console.WriteLine($"Dice rolled. Guess the number in {_maxTries} tries.");

        // Variable to store the tries count
        var triesCount = _maxTries;

        // Loop that will run as long as any tries are left
        while (triesCount > 0)
        {
            var guessing = ConsoleReader.ReadInteger("Enter a number");
            
            if(guessing == diceNumber) return GameResult.Victory;;

            Console.WriteLine("Try again");
            triesCount--;
        }
        // if there are no tries left, return false
        return GameResult.Loss;
    }
}