using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCoreSession.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Qty { get; set; }



        public List<Product> GetProductsInfo()
        {

            var productList = new List<Product>()
            {
                new Product(){Id=1,Name="Iphone 5s",Price=50000.00M},
                new Product(){Id=2,Name="Iphone 6",Price=60000.00M},
                new Product(){Id=3,Name="Iphone 6",Price=70000.00M},
                new Product(){Id=4,Name="Iphone 8",Price=80000.00M},
                new Product(){Id=5,Name="Samsung s7",Price=87000.00M},
            };


            return productList;
        }
    }
}
