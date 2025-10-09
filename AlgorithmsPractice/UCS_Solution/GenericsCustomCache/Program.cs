var numbers = new List<int> { 5,1,7,2 };
numbers.Sort();

var words = new List<string> { "ddd","aaa","ccc","bbb" };
words.Sort();

var people = new List<Person>
{
    new Person{Name = "Jhon", YearOfBirth = 1980},
    new Person {Name = "Anna", YearOfBirth = 1815},
    new Person{Name = "Bill", YearOfBirth = 2150}
};

// Invalid operation exception: The Person list doesn't implement
// IComparable to call someObject.CompareTo(otherObject)
// C# doesn't know how to order items from People
// people.Sort();

var people1 = new List<ComparablePerson>
{
    new ComparablePerson{Name = "Jhon", YearOfBirth = 1980},
    new ComparablePerson{Name = "Anna", YearOfBirth = 1815},
    new ComparablePerson{Name = "Bill", YearOfBirth = 2150}
};

people1.Sort();

Console.ReadKey();

public class Person
{
    public string Name { get; init; }
    public int YearOfBirth { get; init; }
}

// ComparablePerson : IComparable<Person>
// used to compare 2 objects of the same type
public class ComparablePerson : IComparable<ComparablePerson>
{
    public string Name { get; init; }
    public int YearOfBirth { get; init; }

    // Younger to the left, older to the right
    public int CompareTo(ComparablePerson other)
    {
        if (YearOfBirth == other.YearOfBirth) return 0;
        return YearOfBirth < other.YearOfBirth ? 1 : -1;
    }
}

// if a < b is true return 1,   b goes left => b ... a
// if a < b is false return -1, a goes left => a ... b

// 1980 1815 2150
// 1980 < 1815 F    1980 younger left ... 1815 older right
// 2150 < 1980 F    2150 younger left ... 1980 older right 
// 2150 < 1815 F    2150 younger left ... 1815 older right
// *** 2150 1980 1815