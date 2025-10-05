using System.Text.Json;

var app = new GameDataParserApp();
var logger = new Logger("log.txt");

// Global catch block
try
{
    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine("The app has an unexpected error.");
    logger.Log(ex);
}

Console.WriteLine("Press any key to exit.");
Console.ReadKey();

public class GameDataParserApp
{

    public void Run()
    {
        bool isFileRead = false;
        var fileContents = default(string);
        var fileName = default(string);

        do
        {
            Console.WriteLine("Enter the file name.");
            fileName = Console.ReadLine();

            // Providing different statements to indicate what happened
            if (string.IsNullOrEmpty(fileName))
                Console.WriteLine("File name cannot be null or empty.");
            else if (!File.Exists(fileName))
                Console.WriteLine("File does not exist.");
            else
            {
                fileContents = File.ReadAllText(fileName);
                isFileRead = true;
            }
        }
        while (!isFileRead);

        List<VideoGame> games = default;

        // Try catch still required because
        // it throws a new exception with enriching information about the file path
        // tells the user the Json is invalid
        // prints it to the console
        try
        {
            games = JsonSerializer.Deserialize<List<VideoGame>>(fileContents);

        }
        catch (JsonException jsonEx)
        {
            var originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"JSON in file {fileName} was not in valid format. JSON body: {fileContents}");
            Console.ForegroundColor = originalColor;

            // When putting a breakpoint, the IDE doesn't show the file name
            // Re throwing the catch exception adding the filename
            throw new JsonException(
        $@"EX message: {jsonEx.Message}.
        FILE: {fileName}",jsonEx);
        }

        if (games.Count > 0)
        {
            foreach (var game in games)
            {
                Console.WriteLine(game);
                Console.WriteLine();
            }
        }
        else Console.WriteLine("No games found.");

    }

}

public class VideoGame
{
    public string Title { get; init; }
    public int ReleaseYear { get; init; }
    public double Rating { get; init; }

    public override string ToString() =>
         $"{Title}, {ReleaseYear}, {Rating}";
}