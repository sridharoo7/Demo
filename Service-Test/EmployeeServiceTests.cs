using Services;
using Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_Test
{
    public class EmployeeServiceTests
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeServiceTests()
        {
            _employeeService = new EmployeeService();
        }
        [Fact]
        public void GetCustomer_WhenEmployeeIDPasses_ShouldReturnEmployee()
        {
            //Arrange 
            int id = 2;
            Employee employee = new Employee() { Id = 2, FirstName = "Sam", LastName = "Ch", DateOfBirth = DateTime.Now, ZipCode = "75063", Address = "Apt 123", City = "Dallas", Department = "Auto", DateOfJoining = DateTime.Now, Experience = 5 };
            //Act
            var employeeData = _employeeService.GetEmployee(id);
            //Assert
            Assert.NotNull(employeeData);
            Assert.Equal(employee.FirstName, employeeData.FirstName);
            Assert.Equal(employee.LastName, employeeData.LastName);
            Assert.Equal(employee.ZipCode, employeeData.ZipCode);
        }

        [Fact]
        public void GetEmployee_WhenOutOfRangeIDPasses_ShouldReturnNull()
        {
            //Arrange 
            int id = 9;
            //Act
            var customerData = _employeeService.GetEmployee(id);
            //Assert
            Assert.Null(customerData);
        }

        [Fact]
        public void GetEmployee_WhenZeroAsIDPasses_ShouldThrowException()
        {
            //Arrange 
            int id = 0;
            //Assert
            Assert.Throws<Exception>(() => _employeeService.GetEmployee(id));
        }
    }
}
