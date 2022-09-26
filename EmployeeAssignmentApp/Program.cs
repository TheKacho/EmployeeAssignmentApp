using EmployeeAssignmentApp;

Console.WriteLine("Welcome to your new job, user!");

Console.WriteLine("What is your name?");
var name = Console.ReadLine();

Console.WriteLine("What is your birthday?");
var birthdayInput = Console.ReadLine();

DateTime birthday;

while(!DateTime.TryParse(birthdayInput, out birthday))
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