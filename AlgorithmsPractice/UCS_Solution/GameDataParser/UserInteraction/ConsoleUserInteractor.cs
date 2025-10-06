namespace GameDataParser.UserInteraction;

public class ConsoleUserInteractor : IUserInteractor
{
    public void PrintError(string message)
    {
        var originalColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ForegroundColor = originalColor;
    }

    public void PrintMessage(string message) => Console.WriteLine(message);

    public string ReadValidPath()
    {
        bool isFilePathValid = false;
        string fileName;

        do
        {
            PrintMessage("Enter the file name.");
            fileName = Console.ReadLine();

            if (string.IsNullOrEmpty(fileName))
                PrintMessage("File name cannot be null or empty.");
            else if (!File.Exists(fileName))
                PrintMessage("File does not exist.");
            else
            {
                isFilePathValid = true;
            }
        }
        while (!isFilePathValid);

        return fileName;
    }
}