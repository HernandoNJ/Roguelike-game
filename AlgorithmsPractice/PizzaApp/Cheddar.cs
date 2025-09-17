namespace PizzaApp;

public class Cheddar : Cheese
{
    protected override string Name => "Cheddar cheese";
    public int AgedForMonths { get; }

    public Cheddar(int priceIfExtraTopping, int agedForMonths)
        : base(priceIfExtraTopping)
    {
        AgedForMonths = agedForMonths;
        Console.WriteLine("Constructor from Cheddar class");
    }
}