using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VenkatMvc5.Models
{
    [Table("Department")]
    public class Department
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Department Name")]
        public string Name { get; set; }

        public List<Employeee> Employeees { get; set; } // A department can be associate with Many Employees..
    }
}