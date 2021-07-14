using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VenkatMvc5.Models
{
    [Table("Employee")]
    public class Employeee
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Employee Name")]
        public string Name { get; set; }


        [Required]
        public string Gender { get; set; }
        public string City { get; set; }

        public int DeptId { get; set; }

        [ForeignKey("DeptId")]
        public Department Department { get; set; }  //Employee Belongs to specific Department..
    }
}