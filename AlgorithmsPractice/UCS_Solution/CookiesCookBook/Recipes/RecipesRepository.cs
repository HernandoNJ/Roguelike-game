using CookiesCookBook.DataAccess;
using CookiesCookBook.Recipes.Ingredients;

namespace CookiesCookBook.Recipes;

public class RecipesRepository : IRecipesRepository
{
    private readonly IStringsRepository _stringsRepository;
    private readonly IIngredientsRegister _ingredientsRegister;

    private const string Separator = ",";

    public RecipesRepository(IStringsRepository stringsRepository,
                             IIngredientsRegister ingredientsRegister)
    {
        _stringsRepository = stringsRepository;
        _ingredientsRegister = ingredientsRegister;
    }

    public List<Recipe> Read(string filePath)
    {
        List<string> recipesFromFile = _stringsRepository.Read(filePath);
        var recipes = new List<Recipe>();

        foreach (var recipeFromFile in recipesFromFile)
        {
            var recipe = RecipeFromString(recipeFromFile);
            recipes.Add(recipe);
        }

        return recipes;
    }

    private Recipe RecipeFromString(string recipeFromFile)
    {
        var textIds = recipeFromFile.Split(Separator);
        var ingredientsList = new List<Ingredient>();

        foreach (var textId in textIds)
        {
            var id = int.Parse(textId);
            var ingredient = _ingredientsRegister.GetById(id);
            ingredientsList.Add(ingredient);
        }

        return new Recipe(ingredientsList);
    }

    public void Write(string filePath,List<Recipe> allRecipes)
    {
        var recipesAsStringsList = new List<string>();

        foreach (var recipe in allRecipes)
        {
            var Ids = new List<int>();

            foreach (var ingredient in recipe.Ingredients)
            {
                Ids.Add(ingredient.Id);
            }

            recipesAsStringsList.Add(string.Join(Separator,Ids));
        }

        _stringsRepository.Write(filePath,recipesAsStringsList);
    }
}