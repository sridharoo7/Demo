using Services.Model;

namespace Services
{
    public interface ICustomerService
    {
        public Customer GetCustomer(int id);
        public bool UpdateCustomer(Customer customer, int id);
        public bool UpdateCustomerPlan(string plan, int id);
    }
}
