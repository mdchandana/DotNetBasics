using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Data.Models
{
    public class LibraryCard
    {
        public int Id { get; set; }       //This is the foreignKey from Patron table Id

        [Column(TypeName = "decimal(18,2)")]
        public decimal CurrentFees { get; set; }


        public DateTime Issued { get; set; }

        public Patron Patron { get; set; }  //1:1

        public virtual IEnumerable<Checkout> Checkouts { get; set; }
    }
}
