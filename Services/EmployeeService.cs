using Services.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class EmployeeService : IEmployeeService
    {
        private List<User> _userList;
        public EmployeeService()
        {
            _userList = new List<User>()
            {
                new Customer() {Id = 1, FirstName="Ram", LastName="Ch", DateOfBirth=DateTime.Now, ZipCode="75063", Address="Apt 123", City ="Dallas", Plan="Basic", LastPaymentDate = DateTime.Now },
                new Employee() {Id = 2, FirstName="Sam", LastName="Ch", DateOfBirth=DateTime.Now, ZipCode="75063", Address="Apt 123", City ="Dallas", Department="Auto", DateOfJoining = DateTime.Now, Experience = 5},
                new Customer() {Id = 3, FirstName="Hari", LastName="Ch", DateOfBirth=DateTime.Now, ZipCode="75063", Address="Apt 123", City ="Dallas", Plan="Basic", LastPaymentDate = DateTime.Now },
                new Employee() {Id = 4, FirstName="Manu", LastName="Ch", DateOfBirth=DateTime.Now, ZipCode="75063", Address="Apt 123", City ="Dallas", Department="Home", DateOfJoining = DateTime.Now, Experience = 3 },
                new Customer() {Id = 5, FirstName="Suresh", LastName="Ch", DateOfBirth=DateTime.Now, ZipCode="75063", Address="Apt 123", City ="Dallas", Plan="Basic", LastPaymentDate = DateTime.Now },
                new Employee() {Id = 6, FirstName="Ramesh", LastName="Ch", DateOfBirth=DateTime.Now, ZipCode="75063", Address="Apt 123", City ="Dallas", Department="Auto", DateOfJoining = DateTime.Now, Experience = 8 },
                new Customer() {Id = 7, FirstName="Sridhar", LastName="Ch", DateOfBirth=DateTime.Now, ZipCode="75063", Address="Apt 123", City ="Dallas", Plan="Basic", LastPaymentDate = DateTime.Now },
                new Employee() {Id = 8, FirstName="Srikar", LastName="Ch", DateOfBirth=DateTime.Now, ZipCode="75063", Address="Apt 123", City ="Dallas", Department="Home", DateOfJoining = DateTime.Now, Experience = 4 },
            };
        }

        public Employee GetEmployee(int id)
        {
            if (id == 0)
            {
                throw new Exception("Invalid Id");
            }
            return (Employee)_userList.Where(x => x.Id == id && x.GetType() == typeof(Employee)).SingleOrDefault();
        }
    }
}
