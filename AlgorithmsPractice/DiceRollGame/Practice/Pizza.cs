namespace DiceRollGame.Practice;

public class Pizza
{
    // What objects should the list have?
    // A pizza has Cheddar, TomatoSouce, Mozarella
    // But a List can contain only 1 type of object
    // private List<?> _ingredients = new List<????>();
    
    // Let's create an ingredient class
    private List<Ingredient> _ingredients = new List<Ingredient>();

    // Same issue when trying to add an ingredient
    // public void AddIngredient(??? ingredient)=> _ingredients.Add(ingredient);
    
    // New method that accepts Ingredient as a parameter
    public void AddIngredient(Ingredient ingredient)=> _ingredients.Add(ingredient);

    public string Describe() 
        => $"This is a pizza with: {string.Join(", ", ingredients)}";
    
    // Solution 1: create overloads for each ingredient
    // The ingredientes can't be added to the _ingredients list
    // Because it's not a list of Cheddar, TomatoSouce, Mozarella objects
    // Also, the AddIngredient method must be added to each class
    // And we will have a lot of methods doing the same thing
    // Differing only in the parameter types
    // It would look terrible and not maintainable at all
    public void AddIngredient(Cheddar cheddar) => _ingredients.Add(cheddar);
    public void AddIngredients(TomatoSouce tomatoSouce) => _ingredients.Add(tomatoSouce);
    public void AddIngredients(Mozarella mozarella) => _ingredients.Add(mozarella);
}

// Instead of having all those classes, create an Ingredient class
// But the problem is that all those classes have some different properties
// If we put all those properties in the Ingredient class, it will become messy and confusing 
public class Ingredient
{
    public string Name { get; }
    public int AgedForMonths { get; }
    public int TomatosIn100Grams { get; }
    public bool IsLight { get; }
}

public class Cheddar
{
    public string Name = "Cheddar cheese";
    public int AgedForMonths { get; }
}

public class TomatoSouce
{
    public string Name = "Tomato souce";
    public int TomatosIn100Grams { get; }
}

public class Mozarella
{
    public string Name = "Cheddar cheese";
    public bool IsLight { get; }
}