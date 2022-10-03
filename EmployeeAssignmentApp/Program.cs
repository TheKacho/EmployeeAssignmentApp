using EmployeeAssignmentApp;
using System.Linq;
// now, we need to make  a menu with each process and save input data from user
// instead of going through the process everytime on startup

List<Employee> employees = new List<Employee>();
string input = "";
string name = "";

while (input != "x")
{
    ShowMenu();
    input = Console.ReadLine();
    string input = null;
    switch (input)
    {
        case "1":
            AddEmployee();
            ClearConsole();
            break;
        case "2":
            PrintEmployees();
            ClearConsole();
            break;
        case "3":
            RemoveEmployee();
            ClearConsole();
            break;
        default:
            break;
    }
}

void ShowMenu()
{
    Console.Clear();
    Console.WriteLine(@"
Welcome to the employee portal program!
Please choose from the following:
[1] Add employee
[2] View all active employees
[3] Remove Employee
[x] Exit program 
");
}

void ClearConsole()
{
    Console.Write("\nPress any key to continue...");
    Console.Read();
    Console.Clear();
}

void AddEmployee()
{
    Console.WriteLine("Welcome to your new job, user!");

    Console.WriteLine("What is your name?");
    var name = Console.ReadLine();

    Console.WriteLine("What is your birthday?");
    var birthdayInput = Console.ReadLine();

    DateTime birthday;

    while (!DateTime.TryParse(birthdayInput, out birthday))
    {
        //a while loop if the user inputs any nonnumerical answer (like balloon)
        Console.WriteLine("Invalid birthday, try again");
        birthdayInput = Console.ReadLine();
    }

    Console.WriteLine("What is your salary?");
    var salary = Console.ReadLine();

    //makes new instance of Employee from employeee variable
    var employee = new Employee
    {
        Name = name,
        Birthday = birthday,
        Salary = decimal.Parse(salary),
    };

    Console.WriteLine($"Welcome to the company {employee.Name}! " +
        $"Your salary is {employee.Salary} " +
        $"and your birthday is {employee.Birthday.ToShortDateString()}.");

    DateTime myNextBirthday = new DateTime(DateTime.Today.Year, employee.Birthday.Month, employee.Birthday.Day);

    if (myNextBirthday < DateTime.Today)
    {
        myNextBirthday = myNextBirthday.AddYears(1);

    } // if birthday has happened this year then it will add one year

    var daysUntilBirthday = (myNextBirthday - DateTime.Today).Days;
    Console.WriteLine($"Your birthday will bein {daysUntilBirthday} days!");
}

void PrintEmployees()
{
    if (employees.Count == 0)
    {
        Console.WriteLine("There's no employees to display!");
    }
    else
    {
        foreach (Employee employee in employees)
        {
            employee.PrintInfo();
        }
    }
}

void RemoveEmployee()
{
    string name;
    Console.WriteLine("Enter in the employee name you wish to remove:");
    foreach (Employee emp in employees)
    {
        Console.WriteLine(emp.Name);
    }
    name = Console.ReadLine();
    int index = employees.FindIndex(a => a.Name == name);
    if (index == -1)
    {
        Console.WriteLine("Cannot find that employee!");
    }
    else
    {
        employees.RemoveAt(index);
        Console.WriteLine($"{name} has been removed from the list.");
    }
}
