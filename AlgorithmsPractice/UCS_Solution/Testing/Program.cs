using Testing;

var numbers = new List<int>()
{ 1, 4, 6, 12, 44, -1, -8, -19 };

var onlyPositives = true;

var calculator = onlyPositives
    ? new PositiveNumbersCalculator()
    : new NumbersCalculator();

var sum = calculator.CalculateSum(numbers);

Console.WriteLine($"Only positives: {onlyPositives}");
Console.WriteLine($"The sum is {sum}");
Console.WriteLine("Press any key to exit");
Console.ReadKey();