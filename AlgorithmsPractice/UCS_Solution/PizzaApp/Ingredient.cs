namespace PizzaApp;

public class Ingredient
{
    protected virtual string Name => "Ingredient";
    public int PriceIfExtraTopping { get; }
    public override string ToString() => Name;
    
    public Ingredient(int priceIfExtraTopping)
    {
        // Console.WriteLine("Constructor from Ingredient class");
        PriceIfExtraTopping = priceIfExtraTopping;
    }
}