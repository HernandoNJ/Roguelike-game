using CookiesCookBook;
using System.Text.Json;

public class RecipesRepository
{
    private readonly string filePath = Path.Combine("Files", "recipes.json");

    public RecipesRepository()
    {
        // Ensure folder exists
        string? folder = Path.GetDirectoryName(filePath);

        // If the name of the folder is not null or empty
        // and the folder does not exist, create it
        if (!string.IsNullOrEmpty(folder) && !Directory.Exists(folder))
            Directory.CreateDirectory(folder);

        // Ensure file exists
        if (!File.Exists(filePath))
            File.WriteAllText(filePath, "[]"); // empty JSON array
    }

    public List<Recipe> GetAllRecipes()
    {
        var json = File.ReadAllText(filePath);
        var result = JsonSerializer.Deserialize<List<Recipe>>(json);

        if (result != null)
            return result; // return deserialized list
        else
            return new List<Recipe>(); // return empty list if deserialization fails
    }

    public void SaveRecipe(Recipe recipe)
    {
        var recipes = GetAllRecipes();

        if (recipes.Count > 0) recipe.ID = recipes.Count + 1;
        else Console.WriteLine("recipes count is not > 0");

        recipes.Add(recipe);

        var options = new JsonSerializerOptions { WriteIndented = true };
        var json = JsonSerializer.Serialize(recipes, options);

        File.WriteAllText(filePath, json);
    }

    public void ShowFilePath()
    {
        Console.WriteLine($"File path: {Path.GetFullPath(filePath)}");
        Console.WriteLine();
    }
    public void ResetRecipes() => File.WriteAllText(filePath, "[]");
}