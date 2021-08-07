using JqueryAjaxJson.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JqueryAjaxJson.ViewModels
{
    public class EmpLeaveVM
    {

        //This is for Employee Position Select
        public int EmpPositionId { get; set; }
        public SelectList SelectListEmpPositions { get; set; }
        //public IEnumerable<SelectListItem> SelectListItemsEmpPositions { get; set; }



        //This is for Employee Select
        public int EmployeeId { get; set; }
        public SelectList SelectListEmployees { get; set; }


        public LeaveType LeaveType { get; set; }   ///enums fro LeaveType
        public HalfFullLeaveType HalfFullLeaveType { get; set; }   //enums for HalfFullLeaveType
 
    }
}
