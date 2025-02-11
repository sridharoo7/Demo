using Services.Model;

namespace Services
{
    public class CustomerService : ICustomerService
    {
        private List<Customer> _customerList;
        public CustomerService()
        {
            _customerList = new List<Customer>()
            {
                new Customer() {Id = 1, FirstName="Ram", LastName="Ch", Age=21 },
                new Customer() {Id = 2, FirstName="Sam", LastName="Ch", Age=22 },
                new Customer() {Id = 3, FirstName="Hari", LastName="Ch", Age=20 },
                new Customer() {Id = 4, FirstName="Manu", LastName="Ch", Age=21 },
                new Customer() {Id = 5, FirstName="Suresh", LastName="Ch", Age=21 },
                new Customer() {Id = 6, FirstName="Ramesh", LastName="Ch", Age=20 },
                new Customer() {Id = 7, FirstName="Sridhar", LastName="Ch", Age=25 },
                new Customer() {Id = 8, FirstName="Srikar", LastName="Ch", Age=23 },
            };
        }
        public Customer GetCustomer(int id)
        {
            if(id == 0)
            {
                throw new Exception("Invalid Id");
            }
            return _customerList.Where(x => x.Id == id).SingleOrDefault();
        }
    }
}
