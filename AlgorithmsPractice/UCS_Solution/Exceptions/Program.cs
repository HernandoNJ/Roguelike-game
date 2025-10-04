Console.WriteLine("Enter a number.");
var input = Console.ReadLine();
try
{
    var number = ParseStringToInt(input);
    var result = 10 / number;
    Console.WriteLine($"10 / {number} is " + result);
}
// When using several catch blocks, only the first one caught is called
// So it is better to write catch block from more specific to the most generic
catch (FormatException ex)
{
    Console.WriteLine("Input format is wrong. Input is not parsable to int. Ex message " + ex.Message);
}
catch (DivideByZeroException ex)
{
    Console.WriteLine("Diving by zero not allowed. Ex message: " + ex.Message);
}
catch (Exception ex)
{
    // Global exception, after specific ones above
    // General exception is better to be avoided.
    Console.WriteLine("Unexpected error. Ex message: " + ex.Message);
}
finally
{
    Console.WriteLine("Finally block executed.");
}


Console.ReadKey();

int ParseStringToInt(string input) => int.Parse(input);