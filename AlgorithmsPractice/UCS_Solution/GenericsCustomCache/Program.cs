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
    public List<int> FilterBy(string filterType,
                              List<int> numbers)
    {
        switch(filterType)
        {
            case "Even":
                return SelectEvenNumbers(numbers);
            case "Odd":
                return SelectOddNumbers(numbers);
            case "Positive":
                return SelectPositiveNumbers(numbers);
            default: throw new NotSupportedException($"{filterType} is not a valid filter");
        }
    }

    private List<int> SelectEvenNumbers(List<int> numbers)
    {
        var result = new List<int>();

        foreach(var number in numbers)
        {
            if(number % 2 == 0)
                result.Add(number);
        }

        return result;
    }

    private List<int> SelectOddNumbers(List<int> numbers)
    {
        var result = new List<int>();

        foreach(var number in numbers)
        {
            if(number % 2 != 0)
                result.Add(number);
        }

        return result;
    }

    private List<int> SelectPositiveNumbers(List<int> numbers)
    {
        var result = new List<int>();

        foreach(var number in numbers)
        {
            if(number > 0)
                result.Add(number);
        }

        return result;
    }
}