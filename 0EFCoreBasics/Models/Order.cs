using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _0EFCoreBasics.Models
{
    [Table("Order")]
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderedDate { get; set; }        
        public int CustomerId { get; set; }


        //Navigation property for Customer
        //A Order belongs to a specific Customer, OrderId can only be related with a single customer
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }


        //Navigation property for OrderDetails
        //A Order Can be assoicates with OrderDetails many times...
        public List<OrderDetail> OrderDetails { get; set; }


    }
}
