namespace EmployeeAssignmentApp
{
    internal class Menu
    {
        public static List<Employee> AddEmployee(List<Employee> employeeList)
        {
            Console.WriteLine("Enter your name:");
            var name = Console.ReadLine();

            Console.WriteLine("Enter your birthday:");
            var bdayInput = Console.ReadLine();

            DateTime birthday;

            while(!DateTime.TryParse(bdayInput, out birthday))
            {
                Console.WriteLine("Invalid birthday, please try again.");
                bdayInput = Console.ReadLine(); //if invalid format, it allows user to try again
            }

            Console.WriteLine("Enter your salary:");
            var salary = Console.ReadLine();

            var employee = new Employee
            {
                Name = name,
                Birthday = birthday,
                Salary = decimal.Parse(salary)
            };

            employeeList.Add(employee);

            Console.WriteLine($"Welcome to the company. {employee.Name}." +
                $"Your salary is {employee.Salary}" +
                $"Your birthday is {employee.Birthday.ToShortDateString()}.");

            var daysTillNext = GetDaysUntilBirthday(employee.Birthday);
            Console.WriteLine($"It will be {daysTillNext} days until the next birthday!");

            return employeeList; //displays every employee saved through the program
        }

        
        public static void DisplayEmployees(List<Employee> employeeList)
        {
            foreach(Employee employee in employeeList)
            {
                var daysUntilBirthday = GetDaysUntilBirthday(employee.Birthday);
                Console.WriteLine($"Employee {employee.Name} makes {employee.Salary} " +
                    $"and was born on {employee.Birthday.ToShortDateString()}. +" +
                    $"It will be {daysUntilBirthday} days until their next birthday.");
            }
        }

        public static List<Employee> RemoveEmployee(List<Employee> employeeList, string name)
        {
                var employeeToRemove = employeeList.First(item => item.Name == name);
                employeeList.Remove(employeeToRemove);
                return employeeList;           
        }

        public static int GetDaysUntilBirthday(DateTime birthday)
        {
            DateTime nextBirthday = new DateTime(DateTime.Today.Year, birthday.Month, birthday.Day);
            if (nextBirthday < DateTime.Today) //if birthday has already happened this year
            {
                nextBirthday = birthday.AddYears(1); //logic is to add in for next upcoming year
            }

            return (nextBirthday - DateTime.Today).Days;
        }    
    }
}
