using System.Text.Json;

using GameDataParser.Model;
using GameDataParser.UserInteraction;

namespace GameDataParser.DataAccess;

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
