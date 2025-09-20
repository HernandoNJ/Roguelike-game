namespace PizzaApp;

// By making this class abstract
// We avoid having to implement Prepare()
public abstract class Cheese : Ingredient
{
    public Cheese(int priceIfExtraTopping)
        : base(priceIfExtraTopping)
    {
        
    }
}