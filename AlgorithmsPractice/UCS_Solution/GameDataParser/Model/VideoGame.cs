namespace GameDataParser.Model;

public class VideoGame
{
    public string Title { get; init; }
    public int ReleaseYear { get; init; }
    public double Rating { get; init; }

    public override string ToString() =>
         $"{Title}, {ReleaseYear}, {Rating}";
}