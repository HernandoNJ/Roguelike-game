var numbers = new List<int> { 10, 12, -100, 55, 17, 22 };

Console.WriteLine($@"Select filter:
Odd
Even
Positive
");

var userInput = Console.ReadLine();

var filteringStrategy =
    new FilteringStrategySelector()
    .Select(userInput);

List<int> result =
    new NumbersFilter()
    .FilterBy(numbers, filteringStrategy);

Print(result);

Console.ReadKey();

void Print(IEnumerable<int> numbers)
{
    Console.WriteLine(string.Join(",", numbers));
}

public class NumbersFilter
{
    public List<int> FilterBy(List<int> numbers,
                              Func<int, bool> predicate)
    {
        var result = new List<int>();

        foreach(var number in numbers)
        {
            if(predicate(number))
                result.Add(number);
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
        ["Positive"] = number => number > 0
    };

    public Func<int, bool> Select(string filteringType)
        => filteringStrategies[filteringType];
}