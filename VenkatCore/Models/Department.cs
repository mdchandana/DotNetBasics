using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VenkatCore.Models
{
    [Table("Department")]
    public class Department
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Department")]
        public string DeptName { get; set; }

        public List<Employee> Employees { get; set; }   //A Department can be associated many emps.. cardinality 'N'

    }
}
