namespace PizzaApp;

public class Cheddar : Cheese
{
    protected override string Name => "Cheddar cheese";
    public override void Prepare() 
        => Console.WriteLine("Grate and sprinkle over pizza.");

    public int AgedForMonths { get; }

    public Cheddar(int priceIfExtraTopping)
        : base(priceIfExtraTopping) { }
}