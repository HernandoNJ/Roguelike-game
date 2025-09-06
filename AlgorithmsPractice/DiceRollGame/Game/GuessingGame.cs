using DiceRollGame.UserCommunication;

namespace DiceRollGame.Game;
public enum GameResult
{
    Victory,
    Loss
}

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
        var diceResult = _dice.Roll();

        // Initial message
        Console.WriteLine($"Dice rolled. Guess the number in {_maxTries} tries.");

        // Variable to store the tries count
        var triesLeft = _maxTries;

        // Loop that will run as long as any tries are left
        while (triesLeft > 0)
        {
           var guess = ConsoleReader.ReadInteger("Enter a number");
          
           if (guess == diceResult) 
               return GameResult.Victory;
           
           Console.WriteLine("Wrong number");
           --triesLeft;
        }
        return GameResult.Loss;
    }
}