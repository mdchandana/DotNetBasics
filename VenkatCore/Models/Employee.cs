using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VenkatCore.Models
{
    //[Table("Employee")]  //this done with Fluent API
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public Gender Gender { get; set; }


        public string PhotoPath { get; set; }

        public int DeptId { get; set; }


        //[ForeignKey("DeptId")]   //this done with Fluent API
        public Department Department { get; set; }  //Employee belongs to a specific Department .. cardinality '1'
    }
}
