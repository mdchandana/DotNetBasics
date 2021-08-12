using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Data.Models
{
    //========This is having 1 : 1 Relationship with Patron=======
    public class LibraryCard
    {
        public int Id { get; set; }       //This is the foreignKey from Patron table Id   1:1

        [Column(TypeName = "decimal(18,2)")]
        public decimal Fees { get; set; }
        public DateTime Created { get; set; }


        public Patron Patron { get; set; }  //1:1
        public virtual IEnumerable<Checkout> Checkouts { get; set; }
        public virtual IEnumerable<CheckoutHistory> CheckoutHistories { get; set; }
        public virtual IEnumerable<Hold> Holds { get; set; }
    }
}
