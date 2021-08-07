using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JqueryAjaxJson.Models.Interfaces
{
    public interface IEmployeePositionRepository
    {
        List<EmployeePosition> GetAllPositions();
    }
}
