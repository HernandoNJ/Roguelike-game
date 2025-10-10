var numbers = new List<int> { 10, 12, -100, 55, 17, 22 };

Console.WriteLine($@"Select filter:
Odd
Even
");

var userInput = Console.ReadLine();

List<int> result;

switch(userInput)
{
    case "Even":
        result = SelectEvenNumbers(numbers);
        break;
    case "Odd":
        result = SelectOddNumbers(numbers);
        break;
    case "Positive":
        result = SelectPositiveNumbers(numbers);
        break;
    default:
        throw new NotSupportedException($"{userInput} is not a valid filter");
}

Print(result);

Console.ReadKey();

void Print(IEnumerable<int> numbers)
{
    Console.WriteLine(string.Join(",", numbers));
}

List<int> SelectEvenNumbers(List<int> numbers)
{
    var result = new List<int>();

    foreach(var number in numbers)
    {
        if(number % 2 == 0)
            result.Add(number);
    }

    return result;
}

List<int> SelectOddNumbers(List<int> numbers)
{
    var result = new List<int>();

    foreach(var number in numbers)
    {
        if(number % 2 != 0)
            result.Add(number);
    }

    return result;
}

List<int> SelectPositiveNumbers(List<int> numbers)
{
    var result = new List<int>();

    foreach(var number in numbers)
    {
        if(number > 0)
            result.Add(number);
    }

    return result;
}