using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Services;
using Services.Model;
using Web_App.Controllers;

namespace API_Test
{
    public class EmployeeControllerTests
    {
        private readonly Mock<IEmployeeService> _mockEmployeeService;
        private readonly Mock<ILogger<EmployeeController>> _mockLogger;
        private readonly EmployeeController _employeeController;

        public EmployeeControllerTests()
        {
            _mockEmployeeService = new Mock<IEmployeeService>();
            _mockLogger = new Mock<ILogger<EmployeeController>>();
            _employeeController = new EmployeeController(_mockEmployeeService.Object, _mockLogger.Object);
        }

        [Fact]
        public void GetEmployee_WhenPassesID_ShouldReturnCustomer()
        {
            //Arrange
            int id = 1;
            var employee = new Employee() { Id = 1, FirstName = "Ram", LastName = "Ch", DateOfBirth = DateTime.Now };
            _mockEmployeeService.Setup(x => x.GetEmployee(It.IsAny<int>())).Returns(employee);
            //Act
            var data = _employeeController.Get(id);
            //Assert
            Assert.Equivalent(employee, ((ObjectResult)data).Value);
            Assert.Equal(200, ((ObjectResult)data).StatusCode);
            _mockEmployeeService.Verify(x => x.GetEmployee(It.Is<int>(x => x == id)), Times.Once());
        }

        [Fact]
        public void GetEmployee_WhenOutOfRangeIDPasses_ShouldReturnNotFound()
        {
            //Arrange
            int id = 10;
            _mockEmployeeService.Setup(x => x.GetEmployee(It.IsAny<int>())).Returns(value: null);
            //Act
            var data = _employeeController.Get(id);
            //Assert
            Assert.Equal(404, ((ObjectResult)data).StatusCode);
            _mockEmployeeService.Verify(x => x.GetEmployee(It.Is<int>(x => x == id)), Times.Once());
        }

        [Fact]
        public void GetEmployee_WhenZeroAsIDPasses_ShouldThrowException()
        {
            //Arrange
            int id = 0;
            _mockEmployeeService.Setup(x => x.GetEmployee(It.IsAny<int>())).Throws(new Exception("Invalid Id"));
            //Act
            var data = _employeeController.Get(id);
            //Assert
            Assert.Equal(500, ((ObjectResult)data).StatusCode);
            _mockEmployeeService.Verify(x => x.GetEmployee(It.Is<int>(x => x == id)), Times.Once());
        }
    }
}
