var numbers = new[] { 1,4,7,19,2 };
var numbers1 = new[] { 1,3 };

Console.WriteLine("Is any larger than 10? "
                  + IsAnyLargerThan10(numbers));

Console.WriteLine("Is any even? "
                  + IsAnyEven(numbers));

// ------------------------------------------------------

Console.WriteLine("Is any number greater than 10, "
                  + IsAny(numbers1,(n) => n > 10));

Console.WriteLine("Is any number even,"
                  + IsAny(numbers1,(n) => n % 2 == 0));

var isLargerThan10 = IsAny(numbers1,(n) => n > 10);
var isEven = IsAny(numbers1,(n) => n % 2 == 0);

Console.WriteLine("Is any number greater than 10, "
                  + isLargerThan10);

Console.WriteLine("Is any number even,"
                  + isEven);

bool IsLargerThan10Method(int n) => n > 10;
bool IsEvenMethod(int n) => n % 2 == 0;

Func<int,bool> predicateIsLargerThan10_1Func = n => n > 10;
Func<int,bool> predicateIsEven_1Func = n => n % 2 == 0;

Func<int,bool> predicateIsLargerThan10Func = IsLargerThan10Method;
Func<int,bool> predicateIsEvenFunc = IsEvenMethod;

Console.WriteLine("Is any number greater than 10, "
                  + IsAny(numbers,IsLargerThan10Method));

Console.WriteLine("Is any number even, "
                  + IsAny(numbers,IsEvenMethod));

Console.WriteLine("Is any number greater than 10, "
                  + IsAny(numbers,predicateIsLargerThan10Func));

Console.WriteLine("Is any number even, "
                  + IsAny(numbers,predicateIsEvenFunc));

Console.WriteLine("Is any number greater than 10, "
                  + IsAny(numbers,predicateIsLargerThan10_1Func));

Console.WriteLine("Is any number even, "
                  + IsAny(numbers,predicateIsEven_1Func));

Console.ReadKey();

bool IsAnyLargerThan10(IEnumerable<int> numbers)
{
    foreach (int number in numbers)
    {
        // number > 10 is a function that takes a number and returns a boolean
        if (number > 10)
        {
            return true;
        }
    }

    return false;
}

bool IsAnyEven(IEnumerable<int> numbers)
{
    foreach (int number in numbers)
    {
        // number % 2 == 0 is a function that takes a number and returns a boolean
        if (number % 2 == 0)
        {
            return true;
        }
    }

    return false;
}

// It replaces the functions above
bool IsAny(IEnumerable<int> numbers,
           Func<int,bool> boolCheckPredicate)
{
    foreach (int number in numbers)
        if (boolCheckPredicate(number))
            return true;

    return false;
}