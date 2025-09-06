namespace DiceRollGame.UserCommunication;
public static class ConsoleReader
{
    public static int ReadInteger(string message)
    {
        int result;
        
        // Loop that will run as long as the user enters an invalid value
        do
        {
            Console.WriteLine(message);
        }
        while (!int.TryParse(Console.ReadLine(), out result));

        return result;
    }
}