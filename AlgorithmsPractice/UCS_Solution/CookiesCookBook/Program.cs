using static System.Runtime.InteropServices.JavaScript.JSType;

var cookiesRecipesApp = new CookiesRecipesApp();
cookiesRecipesApp.Run();

// The responsibility of this class is to manage
// the application workflow
// This class should be modified only if the workflow changes
public class CookiesRecipesApp
{
    // **** Class analysis ****
    // To keep SRP, we need to implement the steps in other classes
    // So, this class will depend on those classes

    // **** Dependencies ****
    // They will manage the functionalities
    // The dependencies must be private, readonly fields
    // And initialized in the constructor

    // **** Functionalities ****
    // What are the main functionalities?
    // 1. Read and write recipes to a file - RecipesRepository class
    // 2. User interaction - RecipesUserInteraction class

    // **** Work flow ****
    // 1. if any recipe is saved
    // *** store the recipes in a variable
    // *** print existing recipes
    // 2. Print message to create a new recipe
    // 3. Read ingredients from the user
    // 4. if the user selected any ingredients
    // *** Create a new recipe
    // *** Add the new recipe to the saved recipes
    // *** Save the recipes
    // 5. if the user doesnt select any ingredients 
    // *** print no ingredients selected message
    // 3. Print exit message

    private readonly RecipesRepository _recipesRepository;
    private readonly RecipesUserInteraction _recipesUserInteraction;

    public CookiesRecipesApp(RecipesRepository recipesRepository, RecipesUserInteraction recipesUserInteraction)
    {
        _recipesRepository = recipesRepository;
        _recipesUserInteraction = recipesUserInteraction;
    }

    public void Run()
    {
        // 1. if any recipe is saved
        // *** store the recipes in a variable
        // *** print existing recipes
        var allRecipes = _recipesRepository.Read(filePath);
        _recipesUserInteraction.PrintExistingRecipes(allRecipes);

        // 2. Print message to create a new recipe
        _recipesUserInteraction.PromptCreateNewRecipe();

        // 3. Read ingredients from the user
        var ingredients = _recipesUserInteraction.ReadIngredientsFromUser();

        // 4. if the user selects any ingredients
        // *** Create a new recipe
        // *** Add the new recipe to the current recipes
        // *** Save the recipes
        if(ingredients.Count > 0)
        {
            var recipe = new Recipe(ingredients);
            allRecipes.Add(recipe);
            _recipesRepository.Save(allRecipes, filePath);
        }
        
        // 5. if the user doesnt select any ingredients 
        // *** print no ingredients selected message
        // 3. Print exit message

    }
}



