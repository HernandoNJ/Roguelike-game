namespace GameDataParser.UserInteraction;

public interface IUserInteractor
{
    void PrintError(string message);
    void PrintMessage(string message);
    string ReadValidPath();
}