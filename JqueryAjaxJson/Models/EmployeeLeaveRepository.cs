using JqueryAjaxJson.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JqueryAjaxJson.Models
{
    public class EmployeeLeaveRepository : IEmployeeLeaveRepository
    {
        public void AddEmpLeave(List<EmployeeLeave> employeeLeaveList)
        {
            throw new NotImplementedException();
        }

        public List<EmployeeLeave> GetEmpLeavesByEmployeeId(int employeeId)
        {
            throw new NotImplementedException();
        }
    }
}
