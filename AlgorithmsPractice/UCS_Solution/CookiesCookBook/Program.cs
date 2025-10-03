using CookiesCookBook.App;
using CookiesCookBook.DataAccess;
using CookiesCookBook.FileAccess;
using CookiesCookBook.Recipes;
using CookiesCookBook.Recipes.Ingredients;


const FileFormat Format = FileFormat.Txt;
const string FileName = "recipes";
var fileMetaData = new FileMetaData(FileName,Format);
var filePath = fileMetaData.ToPath();

IStringsRepository stringsRepository =
    Format == FileFormat.Json ?
    new StringsJsonRepository() :
    new StringsTextRepository();

var ingredientsRegister = new IngredientsRegister();

var cookiesRecipesApp = new CookiesRecipesApp(
    new RecipesRepository(stringsRepository,ingredientsRegister),
    new RecipesConsoleUserInteraction(ingredientsRegister));

cookiesRecipesApp.Run(filePath);