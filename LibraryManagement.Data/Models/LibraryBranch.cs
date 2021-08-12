using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Data.Models
{
    
    public class LibraryBranch
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required] 
        public string Address { get; set; }

        [Required] 
        public string Telephone { get; set; }

        public string Description { get; set; }
        public DateTime OpenDate { get; set; }  //branch was founded
        public string ImageUrl { get; set; }


        public BranchHours BranchHours { get; set; }  //1:1
        public virtual IEnumerable<Patron> Patrons { get; set; }
        public virtual IEnumerable<LibraryAsset> LibraryAssets { get; set; }
        
        
        
    }
}
