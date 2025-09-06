namespace DiceRollGame.Practice;

public class Pizza
{
    // What objects should the list have?
    // A pizza has Cheddar, TomatoSouce, Mozarella
    // But a List can contain only 1 type of object
    private List<???> _ingredients = new List<>();

    // Same issue when trying to add an ingredient
    public void AddIngredient(? ingredient){
        _ingredients.Add(ingredient);
    }

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