namespace PizzaApp;

public sealed class Mozzarella : Cheese
{
    protected override string Name => "Mozzarella";
    public override void Prepare() 
        => Console.WriteLine("Slice and place on top of the pizza");

    public bool IsLight { get; }

    public Mozzarella(int priceIfExtraTopping)
        : base(priceIfExtraTopping) { }
}