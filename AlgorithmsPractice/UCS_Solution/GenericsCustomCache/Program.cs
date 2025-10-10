var numbers = new List<int> { 10, 12, -100, 55, 17, 22 };

Console.WriteLine($@"Select filter:
Odd
Even
Positive
");

var userInput = Console.ReadLine();

List<int> result = new NumbersFilter().FilterBy(userInput, numbers);

Print(result);

Console.ReadKey();

void Print(IEnumerable<int> numbers)
{
    Console.WriteLine(string.Join(",", numbers));
}

public class NumbersFilter
{
    // Currently the class has 2 functions, breaking SRP
    // Translate the user input to a way of filtering
    // Filter a collection with Select()

    Func<int, bool> isEven = (n) => n % 2 == 0;
    Func<int, bool> isOdd = (n) => n % 2 != 0;
    Func<int, bool> isPositive = (n) => n > 0;

    public List<int> FilterBy(string filterType,
                              List<int> numbers)
    {
        switch(filterType)
        {
            case "Even":
                //return Select(numbers, number => number % 2 == 0);
                return Select(numbers, isEven);
            case "Odd":
                //return Select(numbers, number => number % 2 == 1);
                return Select(numbers, isOdd);
            case "Positive":
                //return Select(numbers, number => number > 0);
                return Select(numbers, isPositive);
            default:
                throw new NotSupportedException($"{filterType} is not a valid filter");
        }
    }

    public List<int> Select(List<int> numbers,
                            Func<int, bool> isValid)
    {
        var result = new List<int>();

        foreach(var number in numbers)
        {
            if(isValid(number))
                result.Add(number);
        }

        return result;
    }
}