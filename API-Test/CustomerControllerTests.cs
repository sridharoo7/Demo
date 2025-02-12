using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Services;
using Services.Model;
using Web_App.Controllers;

namespace API_Test
{
    public class CustomerControllerTests
    {
        private readonly Mock<ICustomerService> _mockCustomerService;
        private readonly Mock<ILogger<CustomerController>> _mockLogger;
        private readonly CustomerController _customerController;
        public CustomerControllerTests()
        {
            _mockCustomerService = new Mock<ICustomerService>();
            _mockLogger = new Mock<ILogger<CustomerController>>();
            _customerController = new CustomerController(_mockCustomerService.Object, _mockLogger.Object);
        }

        [Fact]
        public void GetCustomer_WhenPassesID_ShouldReturnCustomer()
        {
            //Arrange
            int id = 1;
            var customer = new Customer() { Id = 1, FirstName = "Ram", LastName = "Ch", DateOfBirth = DateTime.Now };
            _mockCustomerService.Setup(x=> x.GetCustomer(It.IsAny<int>())).Returns(customer);
            //Act
            var data = _customerController.Get(id);
            //Assert
            Assert.Equivalent(customer,((ObjectResult)data).Value);
            Assert.Equal(200, ((ObjectResult)data).StatusCode);
            _mockCustomerService.Verify(x=>x.GetCustomer(It.Is<int>(x=>x==id)),Times.Once());
        }

        [Fact]
        public void GetCustomer_WhenOutOfRangeIDPasses_ShouldReturnNotFound()
        {
            //Arrange
            int id = 10;
            _mockCustomerService.Setup(x => x.GetCustomer(It.IsAny<int>())).Returns(value: null);
            //Act
            var data = _customerController.Get(id);
            //Assert
            Assert.Equal(404, ((ObjectResult)data).StatusCode);
            _mockCustomerService.Verify(x => x.GetCustomer(It.Is<int>(x => x == id)), Times.Once());
        }

        [Fact]
        public void GetCustomer_WhenZeroAsIDPasses_ShouldThrowException()
        {
            //Arrange
            int id = 0;
            _mockCustomerService.Setup(x => x.GetCustomer(It.IsAny<int>())).Throws(new Exception("Invalid Id"));
            //Act
            var data = _customerController.Get(id);
            //Assert
            Assert.Equal(500, ((ObjectResult)data).StatusCode);
            _mockCustomerService.Verify(x => x.GetCustomer(It.Is<int>(x => x == id)), Times.Once());
        }

        [Fact]
        public void UpdateCustomer_WhenPassesIDAndCustomerData_ShouldReturnOk()
        {
            //Arrange
            int id = 1;
            var customer = new Customer() { Id = 1, FirstName = "Ramesh", LastName = "Ch", DateOfBirth = DateTime.Now, ZipCode = "75063", Address = "Apt 123", City = "Dallas", Plan = "Basic", LastPaymentDate = DateTime.Now };
            _mockCustomerService.Setup(x => x.UpdateCustomer(It.IsAny<Customer>() ,It.IsAny<int>())).Returns(true);
            //Act
            var data = _customerController.UpdateCustomer(id,customer);
            //Assert
            Assert.Equal("Updated", ((ObjectResult)data).Value);
            Assert.Equal(200, ((ObjectResult)data).StatusCode);
            _mockCustomerService.Verify(x => x.UpdateCustomer(It.Is<Customer>(x=>x == customer),It.Is<int>(x => x == id)), Times.Once());
        }

        [Fact]
        public void UpdateCustomer_WhenOutOfRangeIDPasses_ShouldReturnNotFound()
        {
            //Arrange
            int id = 10;
            var customer = new Customer() { Id = 1, FirstName = "Ramesh", LastName = "Ch", DateOfBirth = DateTime.Now, ZipCode = "75063", Address = "Apt 123", City = "Dallas", Plan = "Basic", LastPaymentDate = DateTime.Now };
            _mockCustomerService.Setup(x => x.UpdateCustomer(It.IsAny<Customer>(), It.IsAny<int>())).Returns(false);
            //Act
            var data = _customerController.UpdateCustomer(id,customer);
            //Assert
            Assert.Equal(404, ((ObjectResult)data).StatusCode);
            Assert.Equal("Customer not exist with ID: 10", ((ObjectResult)data).Value);
            _mockCustomerService.Verify(x => x.UpdateCustomer(It.Is<Customer>(x => x == customer), It.Is<int>(x => x == id)), Times.Once());
        }

        [Fact]
        public void UpdateCustomer_WhenZeroAsIDPasses_ShouldThrowException()
        {
            //Arrange
            int id = 0;
            var customer = new Customer() { Id = 1, FirstName = "Ramesh", LastName = "Ch", DateOfBirth = DateTime.Now, ZipCode = "75063", Address = "Apt 123", City = "Dallas", Plan = "Basic", LastPaymentDate = DateTime.Now };
            _mockCustomerService.Setup(x => x.UpdateCustomer(It.IsAny<Customer>(), It.IsAny<int>())).Throws(new Exception("Invalid Id"));
            //Act
            var data = _customerController.UpdateCustomer(id, customer);
            //Assert
            Assert.Equal(500, ((ObjectResult)data).StatusCode);
            _mockCustomerService.Verify(x => x.UpdateCustomer(It.Is<Customer>(x => x == customer), It.Is<int>(x => x == id)), Times.Once());
        }

        [Fact]
        public void UpdateCustomerPlan_WhenPassesIDAndCustomerPlan_ShouldReturnOk()
        {
            //Arrange
            int id = 1;
            _mockCustomerService.Setup(x => x.UpdateCustomerPlan(It.IsAny<string>(), It.IsAny<int>())).Returns(true);
            //Act
            var data = _customerController.UpdateCustomerPlan(id, "Plan");
            //Assert
            Assert.Equal("Updated", ((ObjectResult)data).Value);
            Assert.Equal(200, ((ObjectResult)data).StatusCode);
            _mockCustomerService.Verify(x => x.UpdateCustomerPlan(It.Is<string>(x => x == "Plan"), It.Is<int>(x => x == id)), Times.Once());
        }

        [Fact]
        public void UpdateCustomerPlan_WhenOutOfRangeIDPasses_ShouldReturnNotFound()
        {
            //Arrange
            int id = 10;
            _mockCustomerService.Setup(x => x.UpdateCustomerPlan(It.IsAny<string>(), It.IsAny<int>())).Returns(false);
            //Act
            var data = _customerController.UpdateCustomerPlan(id, "Plan");
            //Assert
            Assert.Equal(404, ((ObjectResult)data).StatusCode);
            Assert.Equal("Customer not exist with ID: 10", ((ObjectResult)data).Value);
            _mockCustomerService.Verify(x => x.UpdateCustomerPlan(It.Is<string>(x => x == "Plan"), It.Is<int>(x => x == id)), Times.Once());
        }

        [Fact]
        public void UpdateCustomerPlan_WhenZeroAsIDorNullorEmpltyPlanPasses_ShouldThrowException()
        {
            //Arrange
            int id = 0;
            _mockCustomerService.Setup(x => x.UpdateCustomerPlan(It.IsAny<string>(), It.IsAny<int>())).Throws(new Exception("Invalid Id"));
            //Act
            var data = _customerController.UpdateCustomerPlan(id, "");
            //Assert
            Assert.Equal(500, ((ObjectResult)data).StatusCode);
            _mockCustomerService.Verify(x => x.UpdateCustomerPlan(It.Is<string>(x => x == ""), It.Is<int>(x => x == id)), Times.Once());
        }
    }
}