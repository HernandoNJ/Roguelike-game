
var cookiesRecipesApp = new CookiesRecipesApp(
    new RecipesRepository(),
    new RecipesConsoleUserInteraction());

cookiesRecipesApp.Run();

public class CookiesRecipesApp
{
    private readonly IRecipesRepository _recipesRepository;
    private readonly IRecipesUserInteraction _recipesUserInteraction;

    public CookiesRecipesApp(IRecipesRepository recipesRepository,
                             IRecipesUserInteraction recipesUserInteraction)
    {
        _recipesRepository = recipesRepository;
        _recipesUserInteraction = recipesUserInteraction;
    }

    public void Run()
    {
        // 1. If any recipes, print them
        // 2. Prompt the user to create a new recipe... Print all ingredients
        // 3. Read user input to select ingredients
        // 4. If user selects at least 1 ingredient ...
        // 5. If user selects no ingredient ...
        // 6. Exit app

        var allRecipes = _recipesRepository.Read(filePath);
        _recipesUserInteraction.ShowExistingRecipes(allRecipes);
        _recipesUserInteraction.PromptToCreateRecipe();
        var ingredients = _recipesUserInteraction.ReadIngredientsFromUser();

        if (ingredients.Count > 0)
        {
            var recipe = new Recipe(ingredients);
            allRecipes.Add(recipe);
            _recipesRepository.Write(filePath, recipe);

            _recipesUserInteraction.ShowMessage("New recipe added.");
            _recipesUserInteraction.ShowMessage(recipe.ToString());
        }
        else
        {
            _recipesUserInteraction.ShowMessage("No recipes added.");
        }
        _recipesUserInteraction.Exit();
    }
}

public interface IRecipesUserInteraction
{
    void ShowMessage(string message);
    void Exit();
}

public interface IRecipesRepository
{
    List<Recipes> Read(string filePath);
    void Write(List<Recipes> allRecipes, filePath);
}

public class RecipesConsoleUserInteraction : IRecipesUserInteraction
{
    public void PromptToCreateRecipe()
    {

    }

    public List<Ingredient> ReadIngredientsFromUser()
    {

    }

    public void ShowExistingRecipes(List<Recipe> allRecipes)
    {

    }

    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }

    public void Exit()
    {
        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }
}

public class RecipesRepository : IRecipesRepository
{
    public List<Recipes> Read(string filePath)
    {

    }

    public void Write(List<Recipes> allRecipes, filePath )
    {

    }
}