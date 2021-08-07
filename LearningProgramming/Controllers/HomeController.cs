using LearningProgramming.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LearningProgramming.Controllers
{
    public class HomeController : Controller
    {
        

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetName( string name)
        {
            return new JsonResult("Welcome ,"+name);
        }



        public IActionResult GetProduct()
        {
            var product = new Product() {Id=1,Name="iphone",Price=75000};

            return new JsonResult(product);
        }



        public IActionResult GetProductList()
        {
            var prouctList = new List<Product>()
            {
                new Product(){Id=1,Name="Iphone 5s",Price=50000},
                new Product(){Id=2,Name="Iphone 7",Price=75000},
                new Product(){Id=3,Name="Samsung s7",Price=87000},
            };

            return new JsonResult(prouctList);
        }




        public IActionResult Privacy()
        {
            return View();
        }

      
    }
}
