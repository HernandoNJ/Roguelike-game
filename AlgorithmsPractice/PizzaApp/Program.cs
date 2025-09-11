using PizzaApp;

var pizza = new Pizza();
pizza.AddIngredient(new Mozarella());
pizza.AddIngredient(new Cheddar());
pizza.AddIngredient(new TomatoSauce());

Console.WriteLine(pizza);

Console.ReadKey();