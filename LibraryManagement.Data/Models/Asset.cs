using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Data.Models
{
    public class Asset
    {
        [Key] 
        public Guid Id { get; set; }

        //public AvailabilityStatus AvailabilityStatus { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Cost { get; set; }

        public string ImageUrl { get; set; }
        public LibraryBranch Location { get; set; }
        //public List<AssetTag> AssetTags { get; set; }
    }
}
