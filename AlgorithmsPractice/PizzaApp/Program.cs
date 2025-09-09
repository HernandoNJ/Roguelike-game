using PizzaApp;

var pizza = new Pizza();
pizza.AddIngredient(new Mozarella());
pizza.AddIngredient(new Cheddar());
pizza.AddIngredient(new TomatoSouce());
Console.WriteLine(pizza.Describe());

var cheddar = new Cheddar();
Console.WriteLine(cheddar.MyNum());
Console.ReadKey();