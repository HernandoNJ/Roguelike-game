using PizzaApp;

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

var ingredient = GenerateRandomIngredient();
Cheddar anotherCheddar = ingredient as Cheddar;

Console.WriteLine($"Name: {anotherCheddar}");

Console.ReadKey();
return;

Ingredient GenerateRandomIngredient()
{
    var random = new Random();
    var number = random.Next(1, 4);
    Console.WriteLine("Random number: " + number);
    
    if (number == 1) return new Cheddar(2, 12);
    if (number == 2) return new TomatoSauce(2, 3);
    
    return new Mozzarella(2,true);
}