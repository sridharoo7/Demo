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
        public void GetCustomer_WhenCustomerIDPasses_ShouldReturnCustomer()
        {
            //Arrange 
            int id = 1;
            Customer customer = new Customer() { Id = 1, FirstName = "Ram", LastName = "Ch", ZipCode = "75063"};
            //Act
            var customerData = _customerService.GetCustomer(id);
            //Assert
            Assert.NotNull(customerData);
            Assert.Equal(customer.FirstName, customerData.FirstName);
            Assert.Equal(customer.LastName, customerData.LastName);
            Assert.Equal(customer.ZipCode, customerData.ZipCode);
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

        [Fact]
        public void UpdateCustomer_WhenCustomerDataPasses_ShouldReturnTrue()
        {
            //Arrange 
            int id = 1;
            Customer customer = new Customer() { Id = 1, FirstName = "Ramesh", LastName = "Ch", DateOfBirth = DateTime.Now, ZipCode = "75063", Address = "Apt 123", City = "Dallas", Plan = "Basic", LastPaymentDate = DateTime.Now };
            //Act
            var res = _customerService.UpdateCustomer(customer,id);
            //Assert
            Assert.NotNull(res);
            Assert.True(res);
        }

        [Fact]
        public void UpdateCustomer_WhenCustomerDataWithInvalidIDPasses_ShouldReturnFalse()
        {
            //Arrange 
            int id = 10;
            Customer customer = new Customer() { Id = 1, FirstName = "Ramesh", LastName = "Ch", DateOfBirth = DateTime.Now, ZipCode = "75063", Address = "Apt 123", City = "Dallas", Plan = "Basic", LastPaymentDate = DateTime.Now };
            //Act
            var res = _customerService.UpdateCustomer(customer, id);
            //Assert
            Assert.NotNull(res);
            Assert.False(res);
        }

        [Fact]
        public void UpdateCustomer_WhenZeroAsIDPasses_ShouldThrowException()
        {
            //Arrange 
            int id = 0;
            //Assert
            Assert.Throws<Exception>(() => _customerService.UpdateCustomer(new Customer(), id));
        }

        [Fact]
        public void UpdateCustomer_WhenNullCustomerDataPasses_ShouldThrowException()
        {
            //Arrange 
            int id = 0;
            //Assert
            Assert.Throws<Exception>(() => _customerService.UpdateCustomer(null, id));
        }

        [Fact]
        public void UpdateCustomerPlan_WhenCustomerPlanPasses_ShouldReturnTrue()
        {
            //Arrange 
            int id = 1;
            //Act
            var res = _customerService.UpdateCustomerPlan("Plan", id);
            //Assert
            Assert.NotNull(res);
            Assert.True(res);
        }

        [Fact]
        public void UpdateCustomerPlan_WhenCustomerPlanWithInvalidIDPasses_ShouldReturnFalse()
        {
            //Arrange 
            int id = 10;
            Customer customer = new Customer() { Id = 1, FirstName = "Ramesh", LastName = "Ch", DateOfBirth = DateTime.Now, ZipCode = "75063", Address = "Apt 123", City = "Dallas", Plan = "Basic", LastPaymentDate = DateTime.Now };
            //Act
            var res = _customerService.UpdateCustomerPlan("Plan", id);
            //Assert
            Assert.NotNull(res);
            Assert.False(res);
        }

        [Fact]
        public void UpdateCustomerPlan_WhenZeroAsIDPasses_ShouldThrowException()
        {
            //Arrange 
            int id = 0;
            //Assert
            Assert.Throws<Exception>(() => _customerService.UpdateCustomer(new Customer(), id));
        }

        [Fact]
        public void UpdateCustomerPlan_WhenNullorEmptyCustomerPlanPasses_ShouldThrowException()
        {
            //Arrange 
            int id = 0;
            //Assert
            Assert.Throws<Exception>(() => _customerService.UpdateCustomerPlan(" ", id));
        }
    }
}