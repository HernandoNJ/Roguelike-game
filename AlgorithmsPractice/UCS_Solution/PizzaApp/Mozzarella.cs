namespace PizzaApp;

public class Mozzarella : Cheese
{
    protected override string Name => "Mozzarella";
    public override void Prepare() 
        => Console.WriteLine("Slice and place on top of the pizza");

    public bool IsLight { get; }

    // The base keyword can be used not only to refer to the base class constructor
    // But any other base class member who is accessible in the derived class
    public Mozzarella(int priceIfExtraTopping, bool isLight)
        : base(priceIfExtraTopping)
    {
        IsLight = isLight;
    }
}