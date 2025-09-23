using CookiesCookBook;

public class RecipesUserInteraction
{
    public void PrintExistingRecipes(string allRecipes)
        => Console.WriteLine("PrintExistingRecipesRecipes: " + allRecipes.ToString());

    public void PromptCreateNewRecipe()
    {
        // Print each ingredient with its ID
        Console.WriteLine("Create a new recipe by selecting ingredients.");
        Console.WriteLine("1. Wheat flour");
        Console.WriteLine("2. Coconut flour");
        Console.WriteLine("3. Butter");
        Console.WriteLine("4. Chocolate");
        Console.WriteLine("5. Sugar");
        Console.WriteLine("6. Cinnamon");
        Console.WriteLine("7. Cocoa powder");
    }

    public Recipe ReadIngredientsFromUser()
    {
        var ingredientIds = new List<int>();

        // Prompt user to add ingredients by their IDs
        while (true)
        {
            Console.WriteLine("Add an ingredient by its ID or type anything else if finished.");

            var userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int number) && number >= 1 && number <= 8)
                ingredientIds.Add(number);
            else
                break; // exit loop if key is not a digit
        }

        // Create a new recipe with the selected ingredients
        if (ingredientIds.Count > 0)
        {
            var ingredientList = new List<Ingredient>();
            var recipe = new Recipe(1, ingredientList);

            // Add ingredients based on user input
            foreach (var id in ingredientIds)
            {
                switch (id)
                {
                    case 1: ingredientList.Add(new Ingredient("Wheat flour", "Sieve. Add to other ingredients.")); break;
                    case 2: ingredientList.Add(new Ingredient("Coconut flour", "Sieve. Add to other ingredients.")); break;
                    case 3: ingredientList.Add(new Ingredient("Butter", "Melt on low heat. Add to other ingredients.")); break;
                    case 4: ingredientList.Add(new Ingredient("Chocolate", "Melt in a water bath. Add to other ingredients.")); break;
                    case 5: ingredientList.Add(new Ingredient("Sugar", "Add to other ingredients.")); break;
                    case 6: ingredientList.Add(new Ingredient("Cardamom", "Take half a teaspoon. Add to other ingredients.")); break;
                    case 7: ingredientList.Add(new Ingredient("Cinnamon", "Take half a teaspoon. Add to other ingredients.")); break;
                    case 8: ingredientList.Add(new Ingredient("Cocoa powder", "Add to other ingredients.")); break;
                }
            }

            // Set a value for recipe.Ingredients
            if (ingredientList != null)
                recipe.Ingredients = ingredientList;

            // Print the added ingredients
            Console.WriteLine("Recipe added with the following ingredients:");
            foreach (var ingredient in recipe.Ingredients)
                Console.WriteLine($"{ingredient.Name}. {ingredient.Instructions}");
            
            return recipe;
        }
        else
        {
            Console.WriteLine("Returning an empty recipe.");
            return new Recipe(0,new List<Ingredient>()); // return an empty recipe
        }
    }

    public void ShowMessage(string message) => Console.WriteLine(message);

    public void Exit()
    {
        Console.WriteLine("Exiting app");
        Environment.Exit(0);
    }
}