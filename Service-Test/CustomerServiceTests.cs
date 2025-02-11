using Services;
using Services.Model;

namespace Service_Test
{
    public class CustomerServiceTests
    {
        private readonly ICustomerService _customerService;

        public CustomerServiceTests()
        {
            _customerService = new CustomerService();
        }
        [Fact]
        public void GetCUstomer_WhenCustomerIDPasses_ShouldReturnCustomer()
        {
            //Arrange 
            int id = 1;
            Customer customer = new Customer() { Id = 1, FirstName = "Ram", LastName = "Ch", Age = 21 };
            //Act
            var customerData = _customerService.GetCustomer(id);
            //Assert
            Assert.NotNull(customerData);
            Assert.Equal(customer.FirstName, customerData.FirstName);
            Assert.Equal(customer.LastName, customerData.LastName);
            Assert.Equal(customer.Age, customerData.Age);
        }

        [Fact]
        public void GetCustomer_WhenOutOfRangeIDPasses_ShouldReturnNull()
        {
            //Arrange 
            int id = 9;
            //Act
            var customerData = _customerService.GetCustomer(id);
            //Assert
            Assert.Null(customerData);
        }

        [Fact]
        public void GetCustomer_WhenZeroAsIDPasses_ShouldThrowException()
        {
            //Arrange 
            int id = 0;
            //Assert
            Assert.Throws<Exception>(()=>_customerService.GetCustomer(id));
        }
    }
}