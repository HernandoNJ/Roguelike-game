namespace PizzaApp;

public abstract class Ingredient
{
    protected virtual string Name => "Ingredient";
    public abstract void Prepare();
    public int PriceIfExtraTopping { get; }
    public override string ToString() => Name;
    
    public Ingredient(int priceIfExtraTopping)
    {
        PriceIfExtraTopping = priceIfExtraTopping;
    }
}