namespace PizzaApp;

public class TomatoSauce : Ingredient
{
    protected override string Name => "Tomato sauce";
    public override void Prepare() 
        => Console.WriteLine("Cook tomatoes.");

    public int TomatoesIn100Grams { get; }

    public TomatoSauce(int priceIfExtraTopping, int tomatoesIn100Grams)
        : base(priceIfExtraTopping)
    {
        TomatoesIn100Grams = tomatoesIn100Grams;
    }
}