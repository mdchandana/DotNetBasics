using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JqueryAjaxJson.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }


        //Every Employee belongs to a specific Position...
        [Required]
        public int EmployeePositionId { get; set; }
        public EmployeePosition EmployeePosition { get; set; }




        //A Employee can be associated with many employees
        public List<EmployeeLeave> EmployeeLeaves { get; set; }
    }
}
