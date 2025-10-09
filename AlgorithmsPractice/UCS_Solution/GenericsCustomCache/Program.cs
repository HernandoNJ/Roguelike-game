var ints = new List<int>() { 1,2,3 };
// The type of T is inferred because
// ints is a List<int>, T is int
// And so the item
// ints.AddToFront<int>(12);
ints.AddToFront(10);

var decimals = new List<decimal> { 1.1m,0.5m,22.5m,12m };
var ints1 = decimals.ConverToIntList();
var ints2 = decimals.ConvertTo<decimal,int>();

var floats = new List<float> { 1.4f,100.01f };
var longs = floats.ConvertTo<float,decimal>();

var dates = new List<DateTime> { new DateTime(2023) };
var ints3 = dates.ConvertTo<DateTime,int>(); // won't work


Console.ReadKey();

public static class ListExtensions
{
    public static void AddToFront<T>(this List<T> list,T item)
    {
        list.Insert(0,item);
    }

    // Non-generic method
    public static List<int> ConverToIntList(this List<decimal> decimals)
    {
        var intsList = new List<int>();

        foreach (var item in decimals)
        {
            intsList.Add((int)item);
        }
        return intsList;
    }

    // Converting from one type to another using T
    public static List<TTarget> ConvertTo<TSource, TTarget>(
        this List<TSource> sourceList)
    {
        var targetList = new List<TTarget>();

        foreach (var item in sourceList)
        {
            var convertedItem =
                (TTarget)Convert.ChangeType(item,typeof(TTarget));

            targetList.Add(convertedItem);
        }

        return targetList;

    }
}