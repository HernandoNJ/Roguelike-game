namespace PizzaApp;

public class Cheddar : Cheese
{
    protected override string Name => "Cheddar cheese";
    public override void Prepare() 
        => Console.WriteLine("Grate and sprinkle over pizza.");

    public int AgedForMonths { get; }

    public Cheddar(int priceIfExtraTopping, int agedForMonths)
        : base(priceIfExtraTopping)
    {
        AgedForMonths = agedForMonths;
        // Console.WriteLine("Constructor from Cheddar class");
    }
}