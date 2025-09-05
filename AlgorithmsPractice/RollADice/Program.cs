using RollADice;

var random = new Random();
var dice = new Dice(random);
var guessingGame = new GuessingGame(dice);

var gameResult = guessingGame.Play();

if (gameResult == GameResult.Victory)
{
    Console.WriteLine("You win!");
}
else Console.WriteLine("You lose!");

