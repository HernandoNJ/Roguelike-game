namespace CookiesCookBook.Test
{
    public class Test
    {
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
            // 3.1 If the user selected any ingredients
            // *** Create a new recipe
            // *** Add the new recipe to the saved recipes
            // *** Save the recipes
            // 3.2 If the user doesnt select any ingredients 
            // *** Print no ingredients selected message
            // 4. Print exit message

            private readonly RecipesRepository _recipesRepository;
            private readonly RecipesUserInteraction _recipesUserInteraction;

            public CookiesRecipesApp(RecipesRepository recipesRepository, RecipesUserInteraction recipesUserInteraction)
            {
                _recipesRepository = recipesRepository;
                _recipesUserInteraction = recipesUserInteraction;
            }

            public void Run()
            {



                // 2. Print message to create a new recipe
                _recipesUserInteraction.PromptCreateNewRecipe();

                // 3. Read ingredients from the user
                _recipesUserInteraction.ReadIngredientsFromUser();

                // 4. If the user selected any ingredients
                // *** Create a new recipe


                // 1. If any recipe is saved
                // *** Store the recipes in a variable
                // *** Print existing recipes
                //var jsonRepo = _recipesRepository.JsonRepo;
                //var recipesPath = jsonRepo.GetPath();
                //var allRecipes = jsonRepo.Read();
                //if (allRecipes.Count > 0)
                //{
                //    _recipesUserInteraction.ShowMessage("No recipes found.");
                //    _recipesUserInteraction.Exit();
                //    return;
                //}
                //else
                //{
                //    foreach (var recipe in allRecipes)
                //    {
                //        _recipesUserInteraction.ShowMessage($"Recipe: {recipe.Name}");
                //        _recipesUserInteraction.ShowMessage("Ingredients: " + string.Join(", ", recipe.Ingredients));
                //        _recipesUserInteraction.ShowMessage("");
                //    }
                //}

                //if (string.IsNullOrWhiteSpace(recipesPath))
                //{
                //    _recipesUserInteraction.ShowMessage("Recipes path is not configured.");
                //    return;
                //}

                //var allRecipes = _recipesRepository.Read();
                //_recipesUserInteraction.PrintExistingRecipes(allRecipes);

                // 2. Print message to create a new recipe
                //_recipesUserInteraction.PromptCreateNewRecipe();

                // 3. Read ingredients from the user
                //var ingredients = _recipesUserInteraction.ReadIngredientsFromUser();

                // 4. If the user selects any ingredients
                // *** Create a new recipe
                // *** Add the new recipe to the current recipes
                // *** Save the recipes
                //if (ingredients.Count > 0)
                //{
                //    // TODO: Parse allRecipes to a List<Recipe>
                //    //var recipe = new Recipe(ingredients);
                //    //var recipeText = string.Join(", ", recipe.ingredients);
                //    //allRecipes.Add(recipesText);
                //    //_recipesRepository.Save(allRecipes, recipesPath);
                //}
                // 5. If the user doesnt select any ingredients 
                //else
                //{
                //    // Print no ingredients selected message
                //    _recipesUserInteraction.ShowMessage("No ingredients selected. Recipe not created.");
                //}

                //Print exit message
                _recipesUserInteraction.Exit();
            }
        }

        // *************************

        //var recipRepos = new RecipesRepository();

        //var recipes = recipRepos.JsonRepo.Read();

        //if (recipes.Count == 0)
        //{
        //    Testing.Error("No recipes found.");
        //    Console.ReadKey();
        //}
        //else
        //    recipes.ForEach(r =>
        //    {
        //        Testing.Info($"Recipe: {r.Name}");
        //        Testing.Info("Ingredients: " + string.Join(", ", r.Ingredients));
        //        Testing.Info();
        //    });
        //Console.ReadKey();

        //recipes.Add(new Recipe("Cake", new List<string> { "Flour", "Sugar", "Eggs" }));
        //recipRepos.JsonRepo.Save(recipes);
    }
}
