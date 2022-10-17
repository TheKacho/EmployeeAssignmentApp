using EmployeeAssignmentApp;
using System.Text.Json;

// now, we need to make  a menu with each process and save input data from user
// instead of going through the process everytime on startup
Console.WriteLine("Welcome to the employee program. Please choose the following:");
Console.WriteLine("1: add employee");
Console.WriteLine("2: view list all employees");
Console.WriteLine("3: Remove employee by name");
Console.WriteLine("4: exit program");

List<Employee> employees = new List<Employee>();

var options = new JsonSerializerOptions
{
    PropertyNameCaseInsensitive = true
};

// assigns text to the directed json file within the project folder
var filetext = File.ReadAllText("employees.json");
var deserialized = JsonSerializer.Deserialize<List<Employee>>(filetext, options);
employees.AddRange(deserialized);

string userInput = Console.ReadLine();

while (userInput != "4")
{
    if (userInput == "1") // this goes to add employeee
    {
        employees = Menu.AddEmployee(employees);
    }
    else if(userInput == "2") // lists all employees
    {
        Menu.DisplayEmployees(employees);
    }
    else if(userInput == "3")
    {
        Console.WriteLine("Please enter employee's name to remove");
        var name = Console.ReadLine();
        Menu.RemoveEmployee(employees, name);
    }
    else if(userInput == "4") //exits the program
    {
        
    }
    Console.WriteLine("What option are you choosing?");
    userInput = Console.ReadLine();
}

//this writes employees data to a json file
var json = JsonSerializer.Serialize(employees);
File.WriteAllText("employees.json", json)


//void ClearConsole()
//{
//    Console.Write("\nPress any key to continue...");
//    Console.Read();
//    Console.Clear();
//}

//void AddEmployee()
//{
//    Console.WriteLine("Welcome to your new job, user!");

//    Console.WriteLine("What is your name?");
//    var name = Console.ReadLine();

//    Console.WriteLine("What is your birthday?");
//    var birthdayInput = Console.ReadLine();

//    DateTime birthday;

//    while (!DateTime.TryParse(birthdayInput, out birthday))
//    {
//        //a while loop if the user inputs any nonnumerical answer (like balloon)
//        Console.WriteLine("Invalid birthday, try again");
//        birthdayInput = Console.ReadLine();
//    }

//    Console.WriteLine("What is your salary?");
//    var salary = Console.ReadLine();

//    //makes new instance of Employee from employeee variable
//    var employee = new Employee
//    {
//        Name = name,
//        Birthday = birthday,
//        Salary = decimal.Parse(salary),
//    };

//    Console.WriteLine($"Welcome to the company {employee.Name}! " +
//        $"Your salary is {employee.Salary} " +
//        $"and your birthday is {employee.Birthday.ToShortDateString()}.");

//    DateTime myNextBirthday = new DateTime(DateTime.Today.Year, employee.Birthday.Month, employee.Birthday.Day);

//    if (myNextBirthday < DateTime.Today)
//    {
//        myNextBirthday = myNextBirthday.AddYears(1);

//    } // if birthday has happened this year then it will add one year

//    var daysUntilBirthday = (myNextBirthday - DateTime.Today).Days;
//    Console.WriteLine($"Your birthday will bein {daysUntilBirthday} days!");
//}

//void PrintEmployees()
//{
//    if (employees.Count == 0)
//    {
//        Console.WriteLine("There's no employees to display!");
//    }
//    else
//    {
//        foreach (Employee employee in employees)
//        {
//            employee.PrintInfo();
//        }
//    }
//}

//void RemoveEmployee()
//{
//    string name;
//    Console.WriteLine("Enter in the employee name you wish to remove:");
//    foreach (Employee emp in employees)
//    {
//        Console.WriteLine(emp.Name);
//    }
//    name = Console.ReadLine();
//    int index = employees.FindIndex(a => a.Name == name);
//    if (index == -1)
//    {
//        Console.WriteLine("Cannot find that employee!");
//    }
//    else
//    {
//        employees.RemoveAt(index);
//        Console.WriteLine($"{name} has been removed from the list.");
//    }
//}
;