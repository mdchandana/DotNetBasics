using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0EFCoreBasics.Models
{
    [Table("Product")]
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        [Column(TypeName ="decimal(18,2)")]
        public decimal Price { get; set; }

        public int QtyInStock { get; set; }

        public int CategoryId { get; set; }

        //A product belongs to a specific category
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }


        //Navigation property product-OrderDetails
        //A product Can be assoicates with OrderDetails many times...
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
