using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VenkatCore.Models
{
    public class SqlEmployeeRepository : IEmployeeRepository
    {
        private AppDbContext _context;

        public SqlEmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public Employee AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee;
        }

        public Employee DeleteEmployee(int id)
        {
            Employee employee = _context.Employees.FirstOrDefault(emp => emp.Id == id);
            if(employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }

            return employee;
        }

        public Employee EditEmployee(Employee empChanges)
        {
            Employee employee = _context.Employees.FirstOrDefault(emp => emp.Id == empChanges.Id);
            if(employee != null)
            {
                employee.Name = empChanges.Name;
                employee.Email = empChanges.Email;
                employee.Gender = empChanges.Gender;
                employee.PhotoPath = empChanges.PhotoPath;

                _context.SaveChanges();
            }

            return empChanges;
        }

        public Employee GetEmployee(int id)
        {
            return _context.Employees.FirstOrDefault(emp => emp.Id == id);

        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _context.Employees.ToList();
        }
    }
}
