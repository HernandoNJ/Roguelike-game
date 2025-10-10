var employees = new List<Employee>
{
    new Employee("Jake", "Space nav", 25000),
    new Employee("Anna", "Space nav", 29000),
    new Employee("Barbara", "Xenobio", 21500),
    new Employee("Damien", "Xenobio", 22000),
    new Employee("Nisha", "Mechanics", 21000),
    new Employee("Gustavo", "Mechanics", 20000)
};

var deptAverageSalary = CalculateAverageSalaryPerDepartment(employees);

foreach(var item in deptAverageSalary)
{
    Console.WriteLine($"Dept: {item.Key}, " +
                      $"AverageSalary: {item.Value}");
}

Console.ReadKey();

Dictionary<string, decimal> CalculateAverageSalaryPerDepartment(IEnumerable<Employee> employees)
{
    //var spaceNavSalaries = new Dictionary<string, decimal>();
    //var xenoBioSalaries = new Dictionary<string, decimal>();
    //var mechanicsSalaries = new Dictionary<string, decimal>();

    //foreach(var employee in employees)
    //{
    //    if(employee.Department == "Space nav")
    //        spaceNavSalaries.Add(employee.Name, employee.MonthlySalary);
    //    else if(employee.Department == "Xenobio")
    //        xenoBioSalaries.Add(employee.Name, employee.MonthlySalary);
    //    else if(employee.Department == "Mechanics")
    //        mechanicsSalaries.Add(employee.Name, employee.MonthlySalary);
    //}

    var spaceNavSalariesSum = 0m;
    var xenobioSalariesSum = 0m;
    var mechanicsSalariesSum = 0m;

    foreach(var employee in employees)
    {
        if(employee.Department == "Space nav")
            spaceNavSalariesSum += employee.MonthlySalary;
        else if(employee.Department == "Xenobio")
            xenobioSalariesSum += employee.MonthlySalary;
        else if(employee.Department == "Mechanics")
            mechanicsSalariesSum += employee.MonthlySalary;
    }

    //Console.WriteLine("space nav sum: " + spaceNavSalariesSum);
    //Console.WriteLine("xenobio sum: " + xenobioSalariesSum);
    //Console.WriteLine("mechanics sum: " + mechanicsSalariesSum);

    var deptAverageSalaryDict = new Dictionary<string, decimal>
    {
        ["SpaceNav"] = spaceNavSalariesSum / 2,
        ["XenoBio"] = xenobioSalariesSum / 2,
        ["Mechanics"] = mechanicsSalariesSum / 2
    };

    return deptAverageSalaryDict;
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