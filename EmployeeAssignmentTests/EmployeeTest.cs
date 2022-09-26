using EmployeeAssignmentApp;

namespace EmployeeAssignmentTests
{
    public class EmployeeTest
    {
        [Fact]
        public void CreateNewEmployeeTest()
        {
            // the arrange and act
            var employee = new Employee();

            // the assert
            Assert.NotNull(employee);
        }
    }
}