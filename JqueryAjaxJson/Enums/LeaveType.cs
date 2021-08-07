using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JqueryAjaxJson.Enums
{
    public enum LeaveType
    {
        [Display(Name = "Casual Leave")]
        CasualLeave = 1,
        [Display(Name = "Duty Leave")]
        DutyLeave = 2
    }
}
