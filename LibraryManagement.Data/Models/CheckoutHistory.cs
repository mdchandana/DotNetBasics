using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Data.Models
{
    public class CheckoutHistory
    {
        public int Id { get; set; }
              

        [Required]
        public DateTime CheckedOut { get; set; }

        public DateTime? CheckedIn { get; set; }


        public int LibraryCardId { get; set; }
        public LibraryCard LibraryCard { get; set; }


        public int LibraryAssetId { get; set; }
        public LibraryAsset LibraryAsset { get; set; }
    }
}
