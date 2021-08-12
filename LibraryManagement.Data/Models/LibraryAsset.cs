using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Data.Models
{
    public class LibraryAsset
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Cost { get; set; }

        public string ImageUrl { get; set; }
        public int NumberOfCopies { get; set; }

        public virtual LibraryBranch LibraryBranch { get; set; }



        //Navigation Properties
        public List<Checkout> Checkouts { get; set; }
        public List<CheckoutHistory> CheckoutHistories { get; set; }
        public virtual IEnumerable<Hold> Holds { get; set; }

    }
}
