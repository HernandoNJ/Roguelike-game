namespace PizzaApp.Notes;

// ReSharper disable once InconsistentNaming
public class Notes_PizzaApp
{
    #region ExtensionMethods

    /*
    The code below could also be used, but it is not type safe
    It returns Enum, but not a specific one
    Because the compiler loses track of the enum type

    public static Enum Next2(this Enum value)
    {
        var type = value.GetType();
        var items = Enum.GetValues(type);
        var index = Array.IndexOf(items, value);

        var nextIndex = (index + 1) % items.Length;
        return (Enum)items.GetValue(nextIndex)!;
    }

    Seasons s = Seasons.Spring;
    var next = s.Next2();  // type of "next" is Enum


    // Error CS0029: cannot implicitly convert type 'System.Enum' to 'Seasons'
    Seasons s = s.Next2();

    enum Colors { Red, Green, Blue }
    Colors color = (Colors)s.Next2(); // Compiles fine, but wrong Enum type

    Console.WriteLine("new season is: " + color); // new season is: Green
    Console.WriteLine("new season type: " + color.GetType()); // new season type: Colors
    */
    #endregion
    
    
}