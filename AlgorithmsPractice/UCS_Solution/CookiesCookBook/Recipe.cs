namespace CookiesCookBook
{
    public class Recipe
    {
        public int ID { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public Recipe(int id, List<Ingredient> ingredients)
        {
            ID = id;
            Ingredients = ingredients;
        }
    }
}
