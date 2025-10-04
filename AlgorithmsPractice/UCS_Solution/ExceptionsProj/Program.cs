var invalidPersonObject = new Person("",-100);
var emptyCollection = new List<int>();
var firstElement = GetFirstElement(emptyCollection);
var firstUsingLinq = emptyCollection.First(); // InvalidOperationException

var numbers = new int[] { 1,2,3 };
var fourth = numbers[3]; // OutOfIndexException

bool has7 = CheckIfContains(7,numbers);

RecursiveMethod2(0);

Console.ReadKey();

int GetFirstElement(IEnumerable<int> numbers)
{
    foreach (int number in numbers)
    {
        return number;
    }

    throw new InvalidOperationException("The collection cannot be empty.");
}

bool CheckIfContains(int value,int[] numbers)
{
    // Prefer not to use this exception
    // Only in case we want to express the method should not be used
    // because it is still in progress
    throw new NotImplementedException();
}

void RecursiveMethod1()
{
    Console.WriteLine("Calling method1");

    // Recursive call generates a StackOverflowException
    RecursiveMethod1();
}

void RecursiveMethod2(int counter)
{
    Console.WriteLine("Calling method2. counter: " + counter);

    // preventing a StackOverflowException by adding a counter
    if (counter < 10)
    {
        RecursiveMethod2(counter + 1);
    }
}

class Person
{
    public string Name { get; }
    public int YearOfBirth { get; }

    public Person(string name,int yearOfBirth = 0)
    {
        if (name is null)
            throw new ArgumentNullException("Name cannot be null");
        if (name == string.Empty)
            throw new ArgumentException("Name cannot be empty.");

        if (yearOfBirth < 1900 || yearOfBirth > DateTime.Now.Year)
            throw new ArgumentOutOfRangeException("Year of birth between 1900 and current year");

        Name = name;
        YearOfBirth = yearOfBirth;
    }
}