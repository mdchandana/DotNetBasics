using DotnetCoreSession.Models;
using DotnetCoreSession.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCoreSession.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {

            Product product = new Product();

            ////simple query....
            //var productsNamesList0 = (from Name in product.GetProductsInfo()
            //                         select Name).ToList();


            ////Here creating a Annonymouse Object Type......
            //var productNameList1 = product.GetProductsInfo()
            //                       .Select(p => new
            //                        {
            //                            Id = p.Id,
            //                            Name = p.Name

            //                        }).ToList();



            //var productNameList2 = (from p in product.GetProductsInfo()
            //                        select new Product()
            //                        {
            //                             Id= p.Id,
            //                             Name=p.Name
            //                        });


            var productNameList3 = product.GetProductsInfo()
                                .Select(p => new Product()
                                {
                                    Id = p.Id,
                                    Name = p.Name

                                }).ToList();




            var productVM = new ProductVM()
            {
                ProductNames = new SelectList(productNameList3, "Id", "Name")
            };

            return View(productVM);
        }






        [HttpPost]
        public JsonResult AddProductToCart(ProductVM productVM)
        {
            return Json("");
        }
    }
}
