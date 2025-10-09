using System.Numerics;

Console.WriteLine($"Sq of 2: {Calculator.Square(2)}");
Console.WriteLine($"Sq of 3m: {Calculator.Square(3m)}");
Console.WriteLine($"Sq of 4d: {Calculator.Square(4d)}");

Console.ReadKey();

public static class Calculator
{
    public static T Square<T>(T input) where T : INumber<T>
        => input * input;
}