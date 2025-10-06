namespace GameDataParser.DataAccess;

public class LocalFileReader : IFileReader
{
    public string Read(string fileName) => File.ReadAllText(fileName);
}
