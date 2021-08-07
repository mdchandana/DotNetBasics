using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0EFCoreBasics.Models
{
    [Table("OrderDetail")]
    public class OrderDetail
    {
        
        public int OrderId { get; set; }
        public int ProductId { get; set; }


        public int Qty { get; set; }


        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; }


        [Column(TypeName = "decimal(18,2)")]
        public decimal Discount { get; set; }



        //--------------------MANY TO MANY-------------------------       
        //--Automatic many many relationships mapping not supported with ef core...
        //--We have create Bridge table manually like this and define Composite key manually..
        //--And Composite key define using [Key] attribute not working with ef core.. we have to define it in DbContext..


        /* Eg :  
         * ------------Composite Key Not working with ef core
         * [Key]                                    [Key]
         * public int OrderId { get; set; }         public int ProductId { get; set; }
         * 
         * we have to define it in DbContext By Fluent API
         */



        [ForeignKey("OrderId")]
        public Order Order { get; set; }   //A OrderDetail belongs to a specific Order 

        [ForeignKey("ProductId")]
        public Product Product { get; set; }  //A OrderDetail belongs to a specific Product 
    }
}
