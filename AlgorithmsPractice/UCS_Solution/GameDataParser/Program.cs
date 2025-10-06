using System.Text.Json;

var consoleInteractor = new ConsoleUserInteractor();

var app = new GameDataParserApp(
    new LocalFileReader(),
    new GamesPrinter(consoleInteractor),
    consoleInteractor,
    new VideoGamesDeserializer(consoleInteractor));

var logger = new Logger("log.txt");

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


#region NOTES
// *** GameDataParserApp Current responsibilities
// 1. Manage the entire workflow of the program
// 2. Implement the details of each step
// Also, currently tightly coupled with Console and File classes
// The unique responsibility of the class is to manage the app workflow

// *** private static string ReadValidPathFromUser()
// It is very general
// It could be used by any other app to ask the user to enter a file name
// Maybe a class about interaction with the user

// *** PrintGames()
// If the way of printing the games changes, for example, 
// add new lines after each video games description
// GameDataParserApp class will have more than 1 reason to change

// *** GamesPrinter class
// As this class will be a dependency of the GameDataParserApp class
// We need to implement an interface
#endregion

/// <summary>
///<i>The unique responsibility of the class is to manage the app workflow</i>
/// </summary>
public class GameDataParserApp
{
    private readonly IFileReader _fileReader;
    private readonly IGamesPrinter _gamesPrinter;
    private readonly IUserInteractor _userInteractor;
    private readonly IVideoGamesDeserializer _videoGamesDeserializer;

    public GameDataParserApp(
        IFileReader fileReader,
        IGamesPrinter gamesPrinter,
        IUserInteractor userInteractor,
        IVideoGamesDeserializer videoGamesDeserializer)
    {
        _fileReader = fileReader;
        _userInteractor = userInteractor;
        _gamesPrinter = gamesPrinter;
        _videoGamesDeserializer = videoGamesDeserializer;
    }

    public void Run()
    {
        string fileName = _userInteractor.ReadValidPath();
        var fileContents = _fileReader.Read(fileName)
        var games = _videoGamesDeserializer.DeserializeFrom(fileName,fileContents);
        _gamesPrinter.Print(games);
    }
}

public interface IFileReader
{
    string Read(string fileName);
}

public class LocalFileReader : IFileReader
{
    public string Read(string fileName) => File.ReadAllText(fileName);
}

public interface IVideoGamesDeserializer
{
    List<VideoGame> DeserializeFrom(string fileName,string fileContents);
}

public class VideoGamesDeserializer : IVideoGamesDeserializer
{
    private readonly IUserInteractor _userInteractor;

    public VideoGamesDeserializer(IUserInteractor userInteractor)
    {
        _userInteractor = userInteractor;
    }

    public List<VideoGame> DeserializeFrom(
        string fileName,string fileContents)
    {
        try
        {
            return JsonSerializer.Deserialize<List<VideoGame>>(fileContents);
        }
        catch (JsonException jsonEx)
        {
            _userInteractor.PrintError($"JSON in file {fileName} was not in valid format. JSON body: {fileContents}");

            throw new JsonException(
                $@"EX message: {jsonEx.Message}.
                FILE: {fileName}",jsonEx);
        }
    }
}

public interface IGamesPrinter
{
    void Print(List<VideoGame> games);
}

///<summary> As this class will be a dependency of the GameDataParserApp class, we need to implement an interface </summary>
public class GamesPrinter : IGamesPrinter
{
    private readonly IUserInteractor _userInteractor;

    public GamesPrinter(IUserInteractor userInteractor)
    {
        _userInteractor = userInteractor;
    }

    public void Print(List<VideoGame> games)
    {
        if (games.Count > 0)
        {
            // Replacing Console.WriteLine() with env.newline
            _userInteractor.PrintMessage(Environment.NewLine + "Loaded games are:");

            foreach (var game in games)
            {
                _userInteractor.PrintMessage(game.ToString());
            }

        }
        else _userInteractor.PrintMessage("No games found.");
    }
}

public interface IUserInteractor
{
    void PrintError(string message);
    void PrintMessage(string message);
    string ReadValidPath();
}

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