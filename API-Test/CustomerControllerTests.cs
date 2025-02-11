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
            var customer = new Customer() { Id = 1, FirstName = "Ram", LastName = "Ch", Age = 21 };
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

    }
}