using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JqueryAjaxJson.Models
{
    public class EmployeePosition
    {
        public int Id { get; set; }

        [Required]
        public string Position { get; set; }

        [Required]
        public string PositionCode { get; set; }


        //A EmployeePsition can be associated with many Employees
        public List<Employee> Employees { get; set; }


    }
}
