using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VenkatCore.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                //new Employee(){Id=2001,Name="Sidath",Email="sidath@gmail.com",Gender=Gender.Male, DeptId=1},
                //new Employee(){Id=2002,Name="Chandana",Email="mdchandana@gmail.com",Gender=Gender.Male,DeptId=2},
                //new Employee(){Id=2003,Name="Madhawa",Email="madhawa@gmail.com",Gender=Gender.Female,DeptId=1},
                //new Employee(){Id=2004,Name="Yasiru",Email="yasiru@gmail.com",Gender=Gender.Male,DeptId=3}

                new Employee(){Id=2001,Name="Sidath",Email="sidath@gmail.com",Gender=Gender.FeMale},
                new Employee(){Id=2002,Name="Chandana",Email="mdchandana@gmail.com",Gender=Gender.Male},
                new Employee(){Id=2003,Name="Madhawa",Email="madhawa@gmail.com",Gender=Gender.FeMale},
                new Employee(){Id=2004,Name="Yasiru",Email="yasiru@gmail.com",Gender=Gender.Male}
            };
        }

        public Employee AddEmployee(Employee employee)
        {
            var newEmpId = _employeeList.Max(emp => emp.Id) + 1;
            employee.Id = newEmpId;
            _employeeList.Add(employee);
            return employee;

        }

        public Employee DeleteEmployee(int id)
        {
            var employee = _employeeList.FirstOrDefault(emp => emp.Id == id);
            if(employee != null)
            {
                _employeeList.Remove(employee);
            }

            return employee;
        }

        public Employee EditEmployee(Employee EmpChanges)
        {
            var employee = _employeeList.FirstOrDefault(emp => emp.Id == EmpChanges.Id);
            if(employee != null)
            {
                employee.Name = EmpChanges.Name;
                employee.Email = EmpChanges.Email;                
                employee.Gender = EmpChanges.Gender;
            }

            return employee;
        }

        public Employee GetEmployee(int id)
        {
            return _employeeList.FirstOrDefault(emp => emp.Id == id);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _employeeList;
        }
    }
}
