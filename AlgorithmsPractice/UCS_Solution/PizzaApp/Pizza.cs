namespace PizzaApp;

public class Pizza
{
    private readonly List<Ingredient> _ingredients = new();

    public void AddIngredient(Ingredient ingredient)
    {
        _ingredients.Add(ingredient);
    }

    public override string ToString()
    {
        return $"This pizza contains {string.Join(", ", _ingredients)}";
    }
}