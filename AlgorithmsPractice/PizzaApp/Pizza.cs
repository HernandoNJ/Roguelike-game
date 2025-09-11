namespace PizzaApp;

public class Pizza
{
    private List<Ingredient> _ingredients = new List<Ingredient>();
    public void AddIngredient(Ingredient ingredient) => _ingredients.Add(ingredient);
    public override string ToString() => $"This pizza contains {string.Join(", ", _ingredients)}";
}