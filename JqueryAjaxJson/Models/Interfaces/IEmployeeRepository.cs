using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JqueryAjaxJson.Models.Interfaces
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployeeByEmpId(int employeeId);
        Employee GetEmployeeByEmpNumber(string empNumber);
        IEnumerable<Employee> GetEmployeesByPositionId(int positionId);
        Employee AddEmployee(Employee employee);
        Employee UpdateEmployee(Employee employee);
    }
}
