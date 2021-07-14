using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VenkatCore.Models
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> GetDepartments();
    }
}
