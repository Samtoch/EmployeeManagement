using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
        
            {
                new Employee() {Id = 1, Name = "Tochi1", Email = "tochi@gmail.com", Department = Dept.HR},
                new Employee() {Id = 2, Name = "Tochi2", Email = "tochi2@gmail.com", Department = Dept.IT},
                new Employee() {Id = 3, Name = "Tochi3", Email = "Tochi3@gmail.com", Department = Dept.Payrol}
            };
        }

        public Employee Add(Employee employee)
        {
            employee.Id = _employeeList.Max(erl => erl.Id) + 1;
            _employeeList.Add(employee);
            return employee; 
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int Id)
        {
            return _employeeList.FirstOrDefault(erl => erl.Id == Id);
        }
    }
}
