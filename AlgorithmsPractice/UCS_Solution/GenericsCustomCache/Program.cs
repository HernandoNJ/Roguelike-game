
var john = new Person { Name = "John",YearOfBirth = 1980 };
var anna = new Person { Name = "Anna",YearOfBirth = 1915 };

PrintInOrder(10,5);
PrintInOrderGeneric(10,5);
PrintInOrderGeneric("aaa","bbb");
PrintInOrderGeneric(anna,john);

Console.ReadKey();

void PrintInOrder(int first,int second)
{
    if (first < second) Console.WriteLine($"{first}, {second}");
    else if (first > second) Console.WriteLine($"{second}, {first}");
}

void PrintInOrderGeneric<T>(T first,T second)
    where T : IComparable<T>
{
    // if called in the first object and returns a positive number (true),
    // first should be moved after the second
    if (first.CompareTo(second) > 0)
    {
        Console.WriteLine($"{second}, {first}");
    }
    else
    {
        Console.WriteLine($"{first}, {second}");
    }
}

public class Person : IComparable<Person>
{
    public string Name { get; init; }
    public int YearOfBirth { get; init; }

    public int CompareTo(Person other)
    {
        if (YearOfBirth < other.YearOfBirth) return 1;
        else if (YearOfBirth > other.YearOfBirth) return -1;
        else return 0;
    }

    public override string ToString() => $"{Name} born in {YearOfBirth}";
}