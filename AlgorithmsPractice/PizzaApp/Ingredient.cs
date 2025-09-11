namespace PizzaApp;

public class Ingredient
{
    protected virtual string Name => "Ingredient";
    public override string ToString() => Name;
}