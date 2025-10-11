var numbers = new List<int> { 10, 12, -100, 55, 17, 22 };
var filteringStrategiesSelector = new FilteringStrategySelector();

Console.WriteLine("Select filter");
Console.WriteLine(
    string.Join(
        Environment.NewLine,
        filteringStrategiesSelector
        .FilteringStrategiesNames));

var userInput = Console.ReadLine();

var filteringStrategy =
    new FilteringStrategySelector()
    .Select(userInput);

var result =
    new Filter()
    .FilterBy(numbers, filteringStrategy);

Print(result);

var words = new[] { "zebra", "ostric", "orch" };
var owords =
    new Filter()
    .FilterBy(
        words,
        word => word.StartsWith("o"));

Console.ReadKey();

void Print(IEnumerable<int> numbers)
{
    Console.WriteLine(string.Join(",", numbers));
}

public class Filter
{
    // Code reusability because it works with any data type (T)
    // eliminating code duplication
    // Type safety by enforcing correct usage at compile time
    // Flexibility by allowing IEnumerable<T>, not just lists
    public IEnumerable<T> FilterBy<T>(IEnumerable<T> items,
                                      Func<T, bool> predicate)
    {
        var result = new List<T>();

        foreach(var item in items)
        {
            if(predicate(item))
                result.Add(item);
        }

        return result;
    }
}

public class FilteringStrategySelector
{
    private readonly Dictionary<string, Func<int, bool>> filteringStrategies = new()
    {
        ["Even"] = number => number % 2 == 0,
        ["Odd"] = number => number % 2 == 1,
        ["Positive"] = number => number > 0,
        ["Negative"] = number => number < 0
    };

    public Func<int, bool> Select(string filteringType)
        => filteringStrategies[filteringType];

    public IEnumerable<string> FilteringStrategiesNames => filteringStrategies.Keys;
}