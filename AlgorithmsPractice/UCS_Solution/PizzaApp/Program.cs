using PizzaApp;

var ingredients = new List<Ingredient>()
{
    new Cheddar(2),
    new Mozzarella(2),
    new TomatoSauce(1)
};

foreach (var ingredient in ingredients) 
    ingredient.Prepare();

Console.ReadKey();
return;

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

var cheddar = new Cheddar(2);
var tomatoSauce = new  TomatoSauce(2);
cheddar.Prepare();
tomatoSauce.Prepare();

var ingredient1 = GenerateRandomIngredient();
Cheddar anotherCheddar = ingredient1 as Cheddar;

Console.WriteLine($"Name: {anotherCheddar}");
Ingredient GenerateRandomIngredient()
{
    var random = new Random();
    var number = random.Next(1, 4);
    Console.WriteLine("Random number: " + number);
    
    if (number == 1) return new Cheddar(2);
    if (number == 2) return new TomatoSauce(2);
    
    return new Mozzarella(2);
}
#endregion