bool isFileRead = false;
var fileContents = default(string);

do
{
    try
    {
        Console.WriteLine("Enter the file name.");
        var fileName = Console.ReadLine();

        // Provide a Json string
        fileContents = File.ReadAllText(fileName);
        isFileRead = true;
    }
    catch (ArgumentNullException ex)
    {
        Console.WriteLine("File name cannot be null");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine("File name cannot be empty");
    }
    catch (FileNotFoundException ex)
    {
        Console.WriteLine("File name not found");
    }
}
while (!isFileRead);


//// Deserialize the Json string
//var videoGames = JsonSerializer.Deserialize<List<VideoGame>>(fileContents);

//if (videoGames.Count > 0)
//{
//    foreach (var videogame in videoGames)
//    {
//        Console.WriteLine(videogame);
//        Console.WriteLine();
//    }
//}
//else Console.WriteLine("No games found.");

Console.ReadKey();

public class VideoGame
{
    public string Title { get; init; }
    public int ReleaseYear { get; init; }
    public double Rating { get; init; }

    public override string ToString() =>
         $"{Title}, {ReleaseYear}, {Rating}";
}