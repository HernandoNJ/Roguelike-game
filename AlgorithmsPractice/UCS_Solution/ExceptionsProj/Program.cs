Console.ReadKey();

int GetFirstElement(IEnumerable<int> numbers)
{
    // It is expected to receive a valid non empty collection
    // with at least 1 item
    // return numbers[0] is not valid as it is IEnumerable
    // foreach is also invalid because the compiler identifies
    // a possible empty collection, so it never enters in the
    // foreach loop and won't return a value
    // So, returning a default value like 0 is not desired
    // also, the compiler won't build and run the app
    // unless a valid item is returned
    foreach (int number in numbers)
    {
        return number;
    }

    // return 0; // avoid this

    // Third option: throwing an exception
    throw new Exception("The collection cannot be empty.");

    /* It makes sense to throw an exception when:
     * 1. We cannot handle invalid input reasonably
     * 2. Invalid input is the developer's mistake */
}

class Person
{
    public string Name { get; }
    public int YearOfBirth { get; }

    public Person(string name,int yearOfBirth = 0)
    {
        /* It makes sense to throw an exception when:
     * 1. We cannot handle invalid input reasonably
     * 2. Invalid input is the developer's mistake */

        if (name == string.Empty)
            throw new Exception("Invalid name.");

        if (yearOfBirth < 1900 || yearOfBirth > DateTime.Now.Year)
            throw new Exception("Invalid year of birth");

        Name = name;
        YearOfBirth = yearOfBirth;
    }

}