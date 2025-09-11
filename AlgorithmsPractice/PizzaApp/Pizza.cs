namespace PizzaApp;

public class Pizza
{
    private List<Ingredient> _ingredients = new List<Ingredient>();
    public void AddIngredient(Ingredient ingredient)=> _ingredients.Add(ingredient);

    // Removed Describe()
    // Instead, using ToString to describe the pizza class
    public override string ToString() 
        => $"This is a pizza with: { string.Join(", ", _ingredients)}";
    
    // *******************************************************************
    // public string Describe() 
    //     => $"This is a pizza with: { string.Join(", ", 
    //         _ingredients.Select(i => i.Name))}";
    
    // public string Describe() 
    //     => $"This is a pizza with: { string.Join(", ", 
    //         _ingredients)}";
    // Result: This is a pizza with: PizzaApp.Mozarella, PizzaApp.Cheddar, PizzaApp.TomatoSouce
}