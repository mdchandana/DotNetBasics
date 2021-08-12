using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Data.Models
{
    //========This is having 1 : 1 Relationship with LibraryBranch=======
    public class BranchHours
    {
        public int Id { get; set; }        //This is the foreignKey from LibraryBranch table Id   1:1

        [Range(0, 6, ErrorMessage = "Day of Week must be between 0 and 6")]
        public int DayOfWeek { get; set; }

        [Range(0, 23, ErrorMessage = "Hour open must be between 0 and 23")]
        public int OpenTime { get; set; }

        [Range(0, 23, ErrorMessage = "Hour closed must be between 0 and 23")]
        public int CloseTime { get; set; }


        public LibraryBranch Branch { get; set; }   //1:1
    }
}
                   