using PizzaApp.Extensions;

var multiLineText =
@"Hello
How
Are
You";

Console.WriteLine("Lines count: " + multiLineText.CountLines());

Console.WriteLine("Next after summer is " + Seasons.Summer.Next());
Console.WriteLine("Next after winter is " + Seasons.Winter.Next());

Console.ReadKey();

public enum Seasons
{
    Spring,
    Summer,
    Autumn,
    Winter
}

#region otherCode

// var pizza = new Pizza();
// pizza.AddIngredient(new Mozarella());
// pizza.AddIngredient(new Cheddar());
// pizza.AddIngredient(new TomatoSauce());
// Console.WriteLine(pizza);

// var ingredient = new Ingredient(1);
// var cheddar = new Cheddar(2,12);
// var ingredient = GenerateRandomIngredient();
// var ingredient1 = new Cheddar(2,1);
// Cheddar anotherCheddar = (Cheddar) new Ingredient(3);

// var cheddar = new Cheddar(2);
// var tomatoSauce = new  TomatoSauce(2);
// cheddar.Prepare();
// tomatoSauce.Prepare();
//
// var ingredient1 = GenerateRandomIngredient();
// Cheddar anotherCheddar = ingredient1 as Cheddar;

//Console.WriteLine($"Name: {anotherCheddar}");

// Ingredient GenerateRandomIngredient()
// {
//     var random = new Random();
//     var number = random.Next(1, 4);
//     Console.WriteLine("Random number: " + number);
//     
//     if (number == 1) return new Cheddar(2);
//     if (number == 2) return new TomatoSauce(2);
//     
//     return new Mozzarella(2);
// }

#endregion