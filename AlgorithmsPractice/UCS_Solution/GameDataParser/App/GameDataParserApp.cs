using GameDataParser.DataAccess;
using GameDataParser.UserInteraction;

namespace GameDataParser.App;

/// <summary><i>
/// The unique responsibility of the class is to manage the app workflow
/// </i> </summary>
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
        var fileContents = _fileReader.Read(fileName);
        var games = _videoGamesDeserializer.DeserializeFrom(fileName,fileContents);
        _gamesPrinter.Print(games);
    }
}
