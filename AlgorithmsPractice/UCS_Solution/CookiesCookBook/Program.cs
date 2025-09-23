var cookiesRecipesApp = new CookiesRecipesApp(new RecipesRepository(), new RecipesUserInteraction());
cookiesRecipesApp.Run();
Console.WriteLine("Press a key to exit");
Console.ReadKey();

public class CookiesRecipesApp
{
    // **** Class analysis ****
    // To keep SRP, we need to implement the steps in other classes
    // So, this class will depend on those classes

    // **** Dependencies ****
    // They will manage the functionalities
    // The dependencies must be private, readonly fields
    // and initialized in the constructor

    // **** Functionalities ****
    // What are the main functionalities?
    // 1. Read and write recipes to a file - RecipesRepository class
    // 2. User interaction - RecipesUserInteraction class

    // **** Work flow ****
    // 1. If any recipe is saved
    // *** Store the recipes in a variable
    // *** Print existing recipes
    // 2. Print message to create a new recipe
    // 3. Read ingredients from the user
    // 4. If the user selected any ingredients
    // *** Create a new recipe
    // *** Add the new recipe to the saved recipes
    // *** Save the recipes
    // 5. If the user doesnt select any ingredients 
    // *** Print no ingredients selected message
    // 6. Print exit message

    private readonly RecipesRepository _recipesRepository;
    private readonly RecipesUserInteraction _recipesUserInteraction;

    public CookiesRecipesApp(RecipesRepository recipesRepository, RecipesUserInteraction recipesUserInteraction)
    {
        _recipesRepository = recipesRepository;
        _recipesUserInteraction = recipesUserInteraction;
    }

    public void Run()
    {
        // 1. If any recipe is saved
        // *** Store the recipes in a variable
        // *** Print existing recipes
        CheckForRecipes();

        // 2. Print message to create a new recipe
        _recipesUserInteraction.PromptCreateNewRecipe();

        // 3. Read ingredients from the user
        var newRecipe = _recipesUserInteraction.ReadIngredientsFromUser();

        if (newRecipe != null && newRecipe.Ingredients.Count > 0)
        {
            // 4. If the user selected any ingredients
            // *** Create a new recipe
            // *** Add the new recipe to the saved recipes
            // *** Save the recipes
            _recipesRepository.SaveRecipe(newRecipe);
        }
        else
        {
            // 5. If the user doesnt select any ingredients 
            // *** Print no ingredients selected message
            Console.WriteLine("No ingredients selected. No recipe created.");
        }

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