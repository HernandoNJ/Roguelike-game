namespace PizzaApp;

public class Mozarella: Ingredient
{
    protected override string Name => "Mozarella";
    public bool IsLight { get; }
}