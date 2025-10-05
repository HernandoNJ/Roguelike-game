using System.Text.Json;

Console.WriteLine("Enter the file name.");
var fileNameInput = Console.ReadLine();

// Provide a Json string
var fileContents = File.ReadAllText(fileNameInput);

// Deserialize the Json string
var videoGames = JsonSerializer.Deserialize<List<VideoGame>>(fileContents);

if (videoGames.Count > 0)
{
    foreach (var videogame in videoGames)
    {
        Console.WriteLine(videogame);
        Console.WriteLine();
    }
}
else Console.WriteLine("No games found.");

Console.ReadKey();

public class VideoGame
{
    public string Title { get; init; }
    public int ReleaseYear { get; init; }
    public double Rating { get; init; }

    public override string ToString()
    {
        return $"{Title}, {ReleaseYear}, {Rating}";
    }
}