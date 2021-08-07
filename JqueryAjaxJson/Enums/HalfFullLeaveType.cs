using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JqueryAjaxJson.Enums
{
    public enum HalfFullLeaveType
    {
        [Display(Name = "Full Day")]
        FullDay = 1,
        [Display(Name = "Half Day")]
        HalfDay = 2
    }
}
