using DiceRollGame.Game;

var random = new Random();
var dice = new Dice(random);
var guessingGame = new GuessingGame(dice);
var gameResult = guessingGame.Play();

Console.WriteLine(gameResult == GameResult.Victory
    ? "You win!"
    : "You lose!");

Console.WriteLine("Press any key to exit");
Console.ReadKey();
