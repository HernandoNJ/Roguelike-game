var cookiesRecipesApp = new CookiesRecipesApp(new RecipesRepository(), new RecipesUserInteraction());
cookiesRecipesApp.Run();

Console.WriteLine("Press a key to exit");
Console.ReadKey();

public class CookiesRecipesApp
{
    private readonly RecipesRepository _recipesRepository;
    private readonly RecipesUserInteraction _recipesUserInteraction;

    public CookiesRecipesApp(RecipesRepository recipesRepository, RecipesUserInteraction recipesUserInteraction)
    {
        _recipesRepository = recipesRepository;
        _recipesUserInteraction = recipesUserInteraction;
    }

    public void Run()
    {
        CheckForRecipes();

        _recipesUserInteraction.PromptCreateNewRecipe();

        var newRecipe = _recipesUserInteraction.ReadIngredientsFromUser();

        if (newRecipe != null && newRecipe.Ingredients.Count > 0)
            _recipesRepository.SaveRecipe(newRecipe);
        else
            Console.WriteLine("No ingredients selected. No recipe created.");

        Console.WriteLine();
    }

    private void CheckForRecipes()
    {
        var allRecipes = _recipesRepository.GetAllRecipes();

        if (allRecipes.Count > 0)
        {
            foreach (var recipe in allRecipes)
            {
                if (recipe != null)
                {
                    Console.WriteLine($"*** {recipe.ID} ***");

                    foreach (var ingredient in recipe.Ingredients)
                    {
                        Console.WriteLine($"{ingredient.Name}: {ingredient.Instructions}");
                    }
                }
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("No recipes found.");
            Console.WriteLine();
        }
    }
}