using CookiesCookBook.Recipes;
using CookiesCookBook.Recipes.Ingredients;

var ingredientsRegister = new IngredientsRegister();

var cookiesRecipesApp = new CookiesRecipesApp(
    new RecipesRepository(new StringsTextRepository(), ingredientsRegister),
    new RecipesConsoleUserInteraction(ingredientsRegister));

cookiesRecipesApp.Run("recipes.txt");

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

    public void Run(string filePath)
    {
        // 1. If any recipes, print them
        // 2. Prompt the user to create a new recipe... Print all ingredients
        // 3. Read user input to select ingredients
        // 4. If user selects at least 1 ingredient ...
        // 5. If user selects no ingredient ...
        // 6. Exit app

        var allRecipes = _recipesRepository.Read(filePath);
        _recipesUserInteraction.PrintExistingRecipes(allRecipes);
        _recipesUserInteraction.PromptToCreateRecipe();
        var ingredients = _recipesUserInteraction.ReadIngredientsFromUser();

        if (ingredients.Count() > 0)
        {
            var recipe = new Recipe(ingredients);
            allRecipes.Add(recipe);
            _recipesRepository.Write(filePath, allRecipes);

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
    void PrintExistingRecipes(IEnumerable<Recipe> allRecipes);
    void PromptToCreateRecipe();
    IEnumerable<Ingredient> ReadIngredientsFromUser();
}

public interface IRecipesRepository
{
    List<Recipe> Read(string filePath);
    void Write(string filePath, List<Recipe> allRecipes);
}

public class RecipesConsoleUserInteraction : IRecipesUserInteraction
{
    private readonly IIngredientsRegister _ingredientsRegister;

    public RecipesConsoleUserInteraction(IIngredientsRegister ingredientsRegister)
    {
        _ingredientsRegister = ingredientsRegister;
    }

    public void PromptToCreateRecipe()
    {
        Console.WriteLine("Create a new cookie recipe! Availabe ingredients are: ");
        foreach (var ingredient in _ingredientsRegister.All)
        {
            Console.WriteLine(ingredient);
        }
    }

    // As the collection is just printed, it will be IEnumerable
    // If an array is provided as parameter, if List<Recipe>, it wouldnt work
    // With IEnumerable, it is possible to provide an array.
    public void PrintExistingRecipes(IEnumerable<Recipe> allRecipes)
    {
        // If there are no recipes, nothing happens
        // Otherwise, print all the recipes separated by * and the recipe number
        if (allRecipes.Count() > 0)
        {
            Console.WriteLine("Existing recipes: " + Environment.NewLine);
            int counter = 1;
            foreach (var recipe in allRecipes)
            {
                Console.WriteLine($"*** {counter} ***");
                Console.WriteLine(recipe);
                Console.WriteLine();
                counter++;
            }
        }
    }

    public IEnumerable<Ingredient> ReadIngredientsFromUser()
    {
        bool shallStop = false;
        var ingredients = new List<Ingredient>();

        while (!shallStop)
        {
            Console.WriteLine("Add an ingredient by Id. Type any other key to finish.");

            // Read user's input and parse it to int
            var userInput = Console.ReadLine();
            var intInput = int.TryParse(userInput, out int id);

            if (intInput)
            {
                // Check if the ingredient is not null
                // If so, add it to the ingredients list
                var selectedIngredient = _ingredientsRegister.GetById(id);

                if (selectedIngredient is not null)
                {
                    ingredients.Add(selectedIngredient);
                }
            }
            else
            {
                shallStop = true;
            }
        }

        return ingredients;
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
        // StringsRepository object reads all lines from a text file
        // e.g. "1,2,3" "2,3" "4,5"
        // It reads a list of strings and returns it as a List<Recipe>
        List<string> recipesFromFile = _stringsRepository.Read(filePath);
        var recipes = new List<Recipe>();

        foreach (var recipeFromFile in recipesFromFile)
        {
            // RecipeFromString() receives a string with ingredient ids
            // that will be used to build a recipe object
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
            // Using Parse insted of TryParse because it is us who creates
            // the file in the write method
            var id = int.Parse(textId);
            var ingredient = _ingredientsRegister.GetById(id);
            ingredientsList.Add(ingredient);
        }

        return new Recipe(ingredientsList);
    }

    public void Write(string filePath, List<Recipe> allRecipes)
    {
        // It receives a List of recipes and writes them as a List of strings
        // e.g. "1,2,3" "2,3" "4,5"
        var recipesAsStringsList = new List<string>();

        foreach (var recipe in allRecipes)
        {
            var Ids = new List<int>();

            foreach (var ingredient in recipe.Ingredients)
            {
                Ids.Add(ingredient.Id);
            }

            recipesAsStringsList.Add(string.Join(Separator, Ids));
        }

        _stringsRepository.Write(filePath, recipesAsStringsList);
    }
}

public interface IIngredientsRegister
{
    IEnumerable<Ingredient> All { get; }

    Ingredient GetById(int id);
}

public class IngredientsRegister : IIngredientsRegister
{
    public IEnumerable<Ingredient> All { get; } =
    [
        new WheatFlour(),
        new SpeltFlour(),
        new Butter(),
        new Chocolate(),
        new Sugar(),
        new Cardamom(),
        new Cinnamon(),
        new CocoaPowder()
    ];

    public Ingredient GetById(int id)
    {
        foreach (var ingredient in All)
        {
            if (ingredient.Id == id) return ingredient;
        }

        return null;
    }
}

public interface IStringsRepository
{
    List<string> Read(string filePath);
    void Write(string filePath, List<string> strings);
}

public class StringsTextRepository : IStringsRepository
{
    private static readonly string Separator = Environment.NewLine;

    public List<string> Read(string filePath)
    {
        if (File.Exists(filePath))
        {
            var fileContents = File.ReadAllText(filePath);
            return fileContents.Split(Separator).ToList();
        }
        return new List<string>();
    }

    public void Write(string filePath, List<string> strings)
    {
        File.WriteAllText(filePath, string.Join(Separator, strings));
    }
}