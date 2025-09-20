namespace PizzaApp;

public class TomatoSauce : Ingredient
{
    protected override string Name => "Tomato sauce";
    public sealed override void Prepare() 
        => Console.WriteLine("Cook tomatoes.");

    public int TomatoesIn100Grams { get; }

    public TomatoSauce(int priceIfExtraTopping)
        : base(priceIfExtraTopping) { }
}

public class SpecialTomatoSauce : TomatoSauce
{
    protected override string Name => "Special tomato sauce";

    public SpecialTomatoSauce(int priceIfExtraTopping) 
        : base(priceIfExtraTopping) { }

    // Compile error
    public override void Prepare() {
        Console.WriteLine("Special tomato sauce prepared.");
    }
}