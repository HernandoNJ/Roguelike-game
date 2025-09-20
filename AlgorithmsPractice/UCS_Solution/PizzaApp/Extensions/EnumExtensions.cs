namespace PizzaApp.Extensions;

public static class EnumExtensions
{
    public static TEnum Next<TEnum>(this TEnum value) 
        where TEnum : struct, Enum
    {
        var enumValues = Enum.GetValues<TEnum>();
        var i = Array.IndexOf(enumValues, value);
        return enumValues[(i + 1) % enumValues.Length];
    }
}
