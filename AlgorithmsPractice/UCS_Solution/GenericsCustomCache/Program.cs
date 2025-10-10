var numbers = new[] { 1,4,7,19,2 };

Console.WriteLine("Is any number greater than 10, "
                  + IsAny(numbers,(n) => n > 10));

Console.WriteLine("Is any number even,"
                  + IsAny(numbers,(n) => n % 2 == 0));

Console.ReadKey();

bool IsAny(IEnumerable<int> numbers,
           Func<int,bool> isValidPredicate)
{
    foreach (int number in numbers)
    {
        if (isValidPredicate(number)) return true;
    }

    return false;
}