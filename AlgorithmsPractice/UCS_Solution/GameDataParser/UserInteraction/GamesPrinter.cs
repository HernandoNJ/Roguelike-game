using GameDataParser.Model;

namespace GameDataParser.UserInteraction;

///<summary>
///As this class will be a dependency of the GameDataParserApp class, we need to implement an interface 
///</summary>
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
            _userInteractor.PrintMessage(Environment.NewLine + "Loaded games are:");

            foreach (var game in games)
                _userInteractor.PrintMessage(game.ToString());
        }
        else _userInteractor.PrintMessage("No games found.");
    }
}