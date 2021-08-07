using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Data.Models
{
    public class Checkout
    {
        public int Id { get; set; }

        [Required] 
        public Asset Asset { get; set; }        
        public DateTime CheckedOutSince { get; set; }
        public DateTime CheckedOutUntil { get; set; }

        public int LibraryCardId { get; set; }
        public LibraryCard LibraryCard { get; set; }
    }
}
