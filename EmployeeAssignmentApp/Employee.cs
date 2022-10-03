using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAssignmentApp
{
    public class Employee
    {
        public string? Name { get; set; }
        public DateTime Birthday { get; set; }
        public decimal Salary { get; set; }

        public void PrintInfo()
        {
            Console.WriteLine($"{Name} is an employeee that makes {Salary.ToString('N')} and was born on {Birthday.Date.ToShortDateString()}. It will be {DaysUntilBirthday()} days until their next birthday.");
        }
    }
}
