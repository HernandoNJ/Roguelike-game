using CookiesCookBook.Test.Interfaces;

namespace CookiesCookBook.Test.Formatters
{
    public class RecipeTxtFormatter : ITextFormatter<RecipeTest>
    {
        public string Serialize(RecipeTest recipe) =>
            recipe is null
                ? throw new ArgumentNullException(nameof(recipe))
                : recipe.ID.ToString();

        public RecipeTest Deserialize(string line)
        {
            if (string.IsNullOrWhiteSpace(line))
                throw new ArgumentException("Input line is null or empty.", nameof(line));

            var trimmed = line.Trim();
            if (int.TryParse(trimmed, out var id))
                return new RecipeTest { ID = id, Ingredients = new List<IngredientTest>() };

            throw new FormatException($"Invalid recipe format: '{line}'. Expected integer ID.");
        }
    }
}
