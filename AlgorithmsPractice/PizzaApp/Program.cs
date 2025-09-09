using PizzaApp;

var pizza = new Pizza();
pizza.AddIngredient(new Mozarella());
pizza.AddIngredient(new Cheddar());
pizza.AddIngredient(new TomatoSouce());
Console.WriteLine(pizza.Describe());

Console.ReadKey();