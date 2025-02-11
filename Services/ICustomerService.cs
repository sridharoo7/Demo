using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Model;

namespace Services
{
    public interface ICustomerService
    {
        public Customer GetCustomer(int id);
    }
}
