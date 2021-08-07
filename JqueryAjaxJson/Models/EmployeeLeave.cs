using JqueryAjaxJson.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JqueryAjaxJson.Models
{
    public class EmployeeLeave
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        [Required]
        public LeaveType LeaveType { get; set; }   //enums

        [Required]
        public DateTime LeaveDate { get; set; }

        [Required]
        public HalfFullLeaveType HalfFullLeaveType { get; set; }   //enums



        //specific EmployeeLeaveId only be associated with a single Employee
        public Employee Employee { get; set; }   


    }
}
