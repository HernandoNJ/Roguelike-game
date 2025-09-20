using PizzaApp;

var cheddar = new Cheddar(2, 3);
var tomatoSauce = new  TomatoSauce(2, 3);
cheddar.Prepare();
tomatoSauce.Prepare();

var ingredients = new List<Ingredient>()
{
    new Cheddar(2, 10),
    new Mozzarella(2,true),
    new TomatoSauce(1, 2)
};

foreach (var ingredient in ingredients)
{
    ingredient.Prepare();
}

Console.ReadKey();
return;

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

var ingredient1 = GenerateRandomIngredient();
Cheddar anotherCheddar = ingredient1 as Cheddar;

Console.WriteLine($"Name: {anotherCheddar}");
Ingredient GenerateRandomIngredient()
{
    var random = new Random();
    var number = random.Next(1, 4);
    Console.WriteLine("Random number: " + number);
    
    if (number == 1) return new Cheddar(2, 12);
    if (number == 2) return new TomatoSauce(2, 3);
    
    return new Mozzarella(2,true);
}