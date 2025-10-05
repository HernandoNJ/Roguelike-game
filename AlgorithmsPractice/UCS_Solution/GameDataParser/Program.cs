using System.Text.Json;

bool isFileRead = false;
var fileContents = default(string);
var fileName = default(string);

do
{
    try
    {
        Console.WriteLine("Enter the file name.");
        fileName = Console.ReadLine();

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
        Console.WriteLine("File does not exist");
    }
}
while (!isFileRead);

List<VideoGame> games = default;

try
{
    games = JsonSerializer.Deserialize<List<VideoGame>>(fileContents);


}
catch (JsonException ex)
{
    var originalColor = Console.ForegroundColor;
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"JSON in file {fileName} was not in valid format. JSON body: {fileContents}");
    Console.ForegroundColor = originalColor;

    // When putting a breakpoint, the IDE doesn't show the file name
    // Re throwing the catch exception adding the filename

    throw new JsonException($"base message: {ex.Message}.\n" +
        $"The file is: {fileName}",ex);
}


if (games.Count > 0)
{
    foreach (var game in games)
    {
        Console.WriteLine(game);
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

    public override string ToString() =>
         $"{Title}, {ReleaseYear}, {Rating}";
}