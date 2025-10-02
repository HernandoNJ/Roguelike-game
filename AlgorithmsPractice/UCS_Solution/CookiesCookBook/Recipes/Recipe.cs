using CookiesCookBook.Recipes.Ingredients.Abc;

namespace CookiesCookBook.Recipes;

public class Recipe
{
    public IEnumerable<Ingredient> Ingredients { get; }

    public Recipe(IEnumerable<Ingredient> ingredients)
    {
        Ingredients = ingredients;
    }
}