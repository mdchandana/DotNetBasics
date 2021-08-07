using JqueryAjaxJson.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JqueryAjaxJson.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private AppDbContext _context;

        public EmployeeRepository(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }


        public IEnumerable<Employee> GetEmployees()
        {
            return _context.Employees.ToList();
        }


        public IEnumerable<Employee> GetEmployeesByPositionId(int positionId)
        {
            return _context.Employees.Where(emp => emp.EmployeePositionId == positionId).ToList();
        }


        public Employee GetEmployeeByEmpId(int employeeId)
        {
            return _context.Employees.FirstOrDefault(emp => emp.Id == employeeId);
        }


        public Employee GetEmployeeByEmpNumber(string empNumber)
        {
            throw new NotImplementedException();
        }

           

        public Employee AddEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        

       

        public Employee UpdateEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
