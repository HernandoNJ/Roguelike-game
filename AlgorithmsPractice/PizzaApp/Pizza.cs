namespace PizzaApp;

public class Pizza
{
    private List<Ingredient> _ingredients = new List<Ingredient>();
    public void AddIngredient(Ingredient ingredient)=> _ingredients.Add(ingredient);

    public string Describe() 
        => $"This is a pizza with: { string.Join(", ", 
                _ingredients.Select(i => i.Name))}";
}