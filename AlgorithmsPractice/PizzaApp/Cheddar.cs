namespace PizzaApp;

public class Cheddar : Ingredient
{
    protected override string Name => "Cheddar cheese";
    public int AgedForMonths { get; }
}