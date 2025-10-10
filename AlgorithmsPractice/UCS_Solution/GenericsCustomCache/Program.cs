var employees = new List<Employee>
{
    new Employee("Jake", "Space nav", 25000),
    new Employee("Anna", "Space nav", 29000),
    new Employee("Barbara", "Xenobio", 21500),
    new Employee("Damien", "Xenobio", 22000),
    new Employee("Nisha", "Mechanics", 21000),
    new Employee("Gustavo", "Mechanics", 20000)
};

var departmentsAverageSalary = CalculateAverageSalaryPerDepartment(employees);

foreach(var item in departmentsAverageSalary)
    Console.WriteLine($"Department: {item.Key}, "
                      + $"Average salary: {item.Value}");

Console.ReadKey();

Dictionary<string, decimal> CalculateAverageSalaryPerDepartment(IEnumerable<Employee> employees)
{
    var departments = new Dictionary<string, List<Employee>>();

    // Grouping department and employees List
    foreach(var employee in employees)
    {
        if(!departments.ContainsKey(employee.Department))
            departments[employee.Department] = new List<Employee>();

        departments[employee.Department].Add(employee);
    }

    var result = new Dictionary<string, decimal>();

    // department key: department's name
    // department value: List<Employee>
    foreach(var department in departments)
    {
        var salariesSum = 0m;

        // loop over each employee in department.Value ... List<Employee>
        foreach(var employee in department.Value)
            salariesSum += employee.MonthlySalary;

        var average = salariesSum / department.Value.Count;
        result[department.Key] = average;
    }

    return result;
}

public class Employee
{
    public Employee(string name, string department, decimal monthlySalary)
    {
        Name = name;
        Department = department;
        MonthlySalary = monthlySalary;
    }

    public string Name { get; init; }
    public string Department { get; init; }
    public decimal MonthlySalary { get; init; }
}