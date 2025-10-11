var numbers = new List<int> { 10, 12, -100, 55, 17, 22 };

Console.WriteLine($@"Select filter:
Odd
Even
Positive
");

var userInput = Console.ReadLine();

// Select the filtering strategy depending on the user input
var filteringStrategy =
    new FilteringStrategySelector()
    .Select(userInput);

List<int> result =
    new NumbersFilter()
    .FilterBy(numbers, filteringStrategy);

void ResultInfo()
{
    // result is a List<int> obtained from FilterBy()
    // FilterBy() requires a List<int> numbers
    //  and a Func<int,bool> called filteringStrategy
    //      filteringStrategy has a string parameter userInput
    //      filteringStrategy compares the userInput to return a Func<int,bool>
    //          For example, if userInput = "Even"
    //          it returns number => number % 2 == 0;
    // ... Now ...
    // List<int> result is the value returned from FilterBy()
    // FilterBy() filters the List<int> numbers
    //  with the return (predicate) of filteringStrategy
    //  it is ... number => number % 2 == 0;
    //  So FilterBy() uses each number in List<int> numbers
    //  And checks against the predicate
    //    if valid, the number is added to a new List<int>
    // After checking all the items in the numbers List<int>
    // FilterBy() returns the new filtered List<int>

    // Use case 2
    // userInput: Odd
    // FilteringStrategySelector().Select(userInput);
    //  case "Odd" ... returns number => number % 2 == 1;
    //  predicate ... number => number % 2 == 1;
    // NumbersFilter().FilterBy(numbers, filteringStrategy);
    // NumbersFilter().FilterBy(numbers, predicate number => number % 2 == 1)
    // A new List<int> result is created in FilterBy()
    // FilterBy() has 2 parameters
    //  List<int> numbers
    //  Func<int,bool> predicate
    //    predicate = number => number % 2 == 1
    // FilterBy() checks each number in numbers against the predicate
    //  if valid, the number is added to the List<int> result
    // FilterBy() returns the new List<int> result
}

Print(result);

Console.ReadKey();

void Print(IEnumerable<int> numbers)
{
    Console.WriteLine(string.Join(",", numbers));
}

public class NumbersFilter
{
    // This class is now completeley independent on the concrete
    // way of numbers filtering
    // It is not aware of the existing algorithms
    // It knows that will apply a strategy ... Func<int, bool> predicate
    // To return a List<int>
    // strategy => Func<int, bool> predicate
    // In this case, it is a strategy for filtering numbers
    // It doesn't care about how the function works
    // It only matters that the function takes an int parameter
    // and returns a bool

    // Open-Closed principle
    // It will not be modified when the strategy is changed or modified in 
    // Func<int, bool> predicate
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

    // string filteringType works as the algorithm's name
    public Func<int, bool> Select(string filteringType)
    {
        return filteringStrategies[filteringType];

        //if(filteringStrategies.ContainsKey(filteringType))
        //    return filteringStrategies[filteringType];
        //else
        //    throw new NotSupportedException($"{filteringType} is not a valid filter");

        //switch(filteringType)
        //{
        //    // Defining a family of simple algorithms
        //    // For each case, number (int) is verified to return a boolean
        //    // Func<int,bool>

        //    // This class will be extended
        //    // It will be extended when a new case is added
        //    // But this class is only focused on providing a mapping
        //    // from the algorithm name to the algorithm implementation
        //    // So the impact of the changed should be low
        //    case "Even":
        //        return number => number % 2 == 0;
        //    case "Odd":
        //        return number => number % 2 == 1;
        //    case "Positive":
        //        return number => number > 0;
        //    default:
        //        throw new NotSupportedException($"{filteringType} is not a valid filter");
        //}
    }
}