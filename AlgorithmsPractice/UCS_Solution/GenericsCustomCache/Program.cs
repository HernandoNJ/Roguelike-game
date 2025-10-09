var people = new List<Person>
{
    new Person{Name = "Jhon", YearOfBirth = 1980},
    new Person {Name = "Anna", YearOfBirth = 1815},
    new Person{Name = "Bill", YearOfBirth = 2150}
};

var employees = new List<Employee>
{
    new Employee {Name = "Jhon", YearOfBirth = 1980},
    new Employee {Name = "Anna", YearOfBirth = 1815},
    new Employee {Name = "Bill", YearOfBirth = 2150}
};

var validPeople = GetOnlyValid(people);
var validEmployees = GetOnlyValid(employees);

foreach (var employee in validEmployees)
{
    // GoToWork is defined in Employee class, but the current
    // result of GetOnlyValid is an IEnumerable<Person>
    // Casting may work, but it is performance expensive
    employee.GoToWork(); // compile error
}

var validPeople1 = GetOnlyValidWithGenerics(people);
var validEmployees1 = GetOnlyValidWithGenerics(employees);

foreach (var employee in validEmployees1)
{
    // validEmployees1 is a collection of Employee
    // casting not required
    employee.GoToWork();
}

Console.ReadKey();

IEnumerable<Person> GetOnlyValid(IEnumerable<Person> persons)
{
    var result = new List<Person>();
    foreach (var person in persons)
    {
        if (person.YearOfBirth > 1900 &&
            person.YearOfBirth < DateTime.Now.Year)
        {
            result.Add(person);
        }
    }
    return result;
}

// TPerson can be of any type derived from Person
// Use it when you want to operate on classes derived from Person
// If not sure, use
// IEnumerable<Person> GetOnlyValid(IEnumerable<TPerson> persons)
// and only add constraints if you are certain you need them.
IEnumerable<TPerson> GetOnlyValidWithGenerics<TPerson>(IEnumerable<TPerson> persons)
    where TPerson : Person
{
    var result = new List<TPerson>();
    foreach (var person in persons)
    {
        if (person.YearOfBirth > 1900 &&
            person.YearOfBirth < DateTime.Now.Year)
        {
            result.Add(person);
        }
    }
    return result;
}

public class Person
{
    public string Name { get; init; }
    public int YearOfBirth { get; init; }
}

public class Employee : Person
{
    public void GoToWork() => Console.WriteLine("Going to work");
}