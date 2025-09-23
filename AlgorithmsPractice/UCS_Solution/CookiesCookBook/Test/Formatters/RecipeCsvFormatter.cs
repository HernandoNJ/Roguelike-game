using CookiesCookBook.Test.Interfaces;

namespace CookiesCookBook.Test.Formatters
{
    public class RecipeCsvFormatter : ITextFormatter<RecipeTest>
    {
        public string Serialize(RecipeTest item)
        {
            return $"{item.ID},{item.Ingredients?.Count ?? 0}";
        }
        public RecipeTest Deserialize(string line)
        {
            var parts = line.Split(',');
            int id = int.Parse(parts[0]);
            int ingredientCount = int.Parse(parts[1]);
            
            return new RecipeTest
            {
                ID = id,
                Ingredients = new List<IngredientTest>(new IngredientTest[ingredientCount])
            };
        }
    }
}
