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
                new Customer() {Id = 1, FirstName="Ram", LastName="Ch", DateOfBirth=DateTime.Now, ZipCode="75063", Address="Apt 123", City ="Dallas", Plan="Basic", LastPaymentDate = DateTime.Now },
                new Customer() {Id = 2, FirstName="Sam", LastName="Ch", DateOfBirth=DateTime.Now, ZipCode="75063", Address="Apt 123", City ="Dallas", Plan="Basic", LastPaymentDate = DateTime.Now },
                new Customer() {Id = 3, FirstName="Hari", LastName="Ch", DateOfBirth=DateTime.Now, ZipCode="75063", Address="Apt 123", City ="Dallas", Plan="Basic", LastPaymentDate = DateTime.Now },
                new Customer() {Id = 4, FirstName="Manu", LastName="Ch", DateOfBirth=DateTime.Now, ZipCode="75063", Address="Apt 123", City ="Dallas", Plan="Basic", LastPaymentDate = DateTime.Now },
                new Customer() {Id = 5, FirstName="Suresh", LastName="Ch", DateOfBirth=DateTime.Now, ZipCode="75063", Address="Apt 123", City ="Dallas", Plan="Basic", LastPaymentDate = DateTime.Now },
                new Customer() {Id = 6, FirstName="Ramesh", LastName="Ch", DateOfBirth=DateTime.Now, ZipCode="75063", Address="Apt 123", City ="Dallas", Plan="Basic", LastPaymentDate = DateTime.Now },
                new Customer() {Id = 7, FirstName="Sridhar", LastName="Ch", DateOfBirth=DateTime.Now, ZipCode="75063", Address="Apt 123", City ="Dallas", Plan="Basic", LastPaymentDate = DateTime.Now },
                new Customer() {Id = 8, FirstName="Srikar", LastName="Ch", DateOfBirth=DateTime.Now, ZipCode="75063", Address="Apt 123", City ="Dallas", Plan="Basic", LastPaymentDate = DateTime.Now },
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

        public bool UpdateCustomer(Customer customer, int id)
        {
            if(id == 0 || customer == null)
            {
                throw new Exception("Invalid Data");
            }
            var data = _customerList.Where(x => x.Id == id).SingleOrDefault();
            if(data == null)
            {
                return false;
            }
            var updatedRecord = _customerList.Where(x => x.Id == id)?.Select(x =>
            {
                x.FirstName = customer.FirstName;
                x.LastName = customer.LastName;
                x.Address = customer.Address;
                x.City = customer.City;
                x.ZipCode = customer.ZipCode;
                x.DateOfBirth = customer.DateOfBirth;
                return x;
            }
            ).SingleOrDefault();
            //DB call to commit changes.
            return true;
        }

        public bool UpdateCustomerPlan(string plan, int id)
        {
            if (id == 0 || string.IsNullOrEmpty(plan.Trim()))
            {
                throw new Exception("Invalid Data");
            }
            var data = _customerList.Where(x => x.Id == id).SingleOrDefault();
            if (data == null)
            {
                return false;
            }
            var updatedRecord = _customerList.Where(x => x.Id == id)?.Select(x =>
            {
                x.Plan = plan;
                return x;
            }
            ).SingleOrDefault();
            //DB call to commit changes.
            return true;
        }
    }
}
