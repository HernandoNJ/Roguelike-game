using CookiesCookBook.Recipes.Ingredients;

namespace CookiesCookBook.Recipes;

public class Recipe
{
    public IEnumerable<Ingredient> Ingredients { get; }

    public Recipe(IEnumerable<Ingredient> ingredients)
    {
        Ingredients = ingredients;
    }

    public override string ToString()
    {
        var recipeInfo = new List<string>();
        foreach (var ingredient in Ingredients)
        {
            recipeInfo.Add($"" +
                $"{ingredient.Name}. " +
                $"{ingredient.PreparationInstructions}");
        }
        return string.Join(Environment.NewLine, recipeInfo);
    }
}