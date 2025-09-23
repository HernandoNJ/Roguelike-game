namespace CookiesCookBook
{
    public class Ingredient
    {
        public string Name { get; set; }
        public string Instructions { get; set; }
        public Ingredient(string name, string instructions)
        {
            Name = name;
            Instructions = instructions;
        }
    }
}
