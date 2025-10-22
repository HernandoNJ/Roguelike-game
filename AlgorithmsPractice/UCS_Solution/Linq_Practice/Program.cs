// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
Console.ReadKey();

public class Test
{
    public override string ToString()
    {
        var namePreparationStringList = Ingredients
            .Select(item => item.Name + ". --- "
                            + item.PreparationInstructions)
            .ToList();

        return string.Join(Environment.NewLine,
                           namePreparationStringList);

        // *****************

        var steps = new List<string>();

        foreach(var ingredient in Ingredients)
        {
            steps.Add($"{ingredient.Name}. {ingredient.PreparationInstructions}");
        }

        return string.Join(Environment.NewLine, steps);
    }

    public List<Recipe> Read(string filePath)
    {
        List<string> recipesFromFile = _stringsRepository.Read(filePath);

        var recipes2 = recipesFromFile.Select(RecipeFromString).ToList();

        return recipes2;

        // Transform each string into a recipe
        // Collect the results
        var recipes1 = recipesFromFile
            .Select(item => RecipeFromString(item)).ToList();

        var recipes = new List<Recipe>();

        foreach(var recipeFromFile in recipesFromFile)
        {
            //Transformation -> (Select) : recipeFromFile to recipe
            var recipe = RecipeFromString(recipeFromFile);

            //Collection -> (ToList) : Add
            recipes.Add(recipe);
        }
    }

    private Recipe RecipeFromString(string recipeFromFile)
    {
        var textIdsArray = recipeFromFile.Split(Separator);

        var ingredients3 = textIdsArray
            .Select(textId
                => _ingredientsRegister.GetById(int.Parse(textId)))
            .ToList();

        return new Recipe(ingredients3);

        var ingredients1 = textIdsArray
            .Select(textId
                => _ingredientsRegister.GetById(int.Parse(textId)))
            .ToList();

        var ingredients2 = textIdsArray
            .Select(textId => int.Parse(textId))
            .Select(id => _ingredientsRegister.GetById(id))
            .ToList();


        var ingredients = new List<Ingredient>();

        foreach(var textualId in textIdsArray)
        {
            var id = int.Parse(textualId);
            var ingredient = _ingredientsRegister.GetById(id);
            ingredients.Add(ingredient);
        }

    }

    public void Write(string filePath, List<Recipe> allRecipes)
    {
        /*  var recipesAsIdsArray
         *  from allRecipes
         *      .Select each recipe from all recipes
         *      for every recipe,
         *          var allIds
         *          from every recipe.Ingredients
         *              .Select each ingredient.Id
         *  ToList() */

        var recipesAsIdsArray = allRecipes
            .Select(recipe =>
            {
                var allIds = recipe.Ingredients
                .Select(IngredientItem => IngredientItem.Id);

                return string.Join(Separator, allIds);
            })
            .ToList();

        _stringsRepository.Write(filePath, recipesAsIdsArray);

        return;

        var recipesAsIdsArray1 = new List<string>();

        foreach(var recipe in allRecipes)
        {
            var allIds = new List<int>();

            foreach(var ingredient in recipe.Ingredients)
                allIds.Add(ingredient.Id);

            recipesAsIdsArray.Add(string.Join(Separator, allIds));
        }

        _stringsRepository.Write(filePath, recipesAsIdsArray1);
    }
}