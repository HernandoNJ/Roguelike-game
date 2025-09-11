namespace PizzaApp;

public class TomatoSauce: Ingredient
{
    protected override string Name => "Tomato sauce";
    public int TomatosIn100Grams { get; }
}