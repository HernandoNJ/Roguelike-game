using CookiesCookBook.Test.Formatters;
using CookiesCookBook.Test.Interfaces;

namespace CookiesCookBook.Test.Repos
{
    public class RecipesRepository
    {
        public IRepository<RecipeTest> JsonRepo { get; }
        public IRepository<RecipeTest> TxtRepo { get; }
        public IRepository<RecipeTest> XmlRepo { get; }

        public RecipesRepository()
        {
            JsonRepo = new JsonRepository<RecipeTest>("Files","recipes.json");
            TxtRepo = new TextFileRepository<RecipeTest>("Files","recipes.txt", new RecipeTxtFormatter());
            XmlRepo = new XmlRepository<RecipeTest>("Files","recipes.xml");
        }
    }
}
