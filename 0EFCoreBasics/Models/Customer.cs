using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0EFCoreBasics.Models
{
    [Table("Customer")]
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }



        //Navigation Property for Order.....
        //Customer can have many orders , But a Order belongs to a specific Customer..
        public List<Order> Orders { get; set; } 
    }
}
