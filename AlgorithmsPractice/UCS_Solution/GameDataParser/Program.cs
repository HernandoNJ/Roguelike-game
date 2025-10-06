using GameDataParser.App;
using GameDataParser.DataAccess;
using GameDataParser.Logging;
using GameDataParser.UserInteraction;

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