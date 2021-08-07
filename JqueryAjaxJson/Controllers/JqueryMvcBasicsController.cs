using JqueryAjaxJson.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JqueryAjaxJson.Controllers
{
    public class JqueryMvcBasicsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetInfo()
        {
            return Json( new {name="Chandana",age=39 } );   //passing anonymouse json object
        }



        [HttpGet]
        public IActionResult GetName(string name)
        {
            //return new JsonResult("Welcome ," + name);   //worked
            return Json("Welcome ," + name);
        }


        [HttpGet]
        public JsonResult GetProduct()
        {
            var product = new Product() { Id = 1, Name = "iphone", Price = 75000 };

            return Json(product);
        }



        public IActionResult GetProductList()
        {
            var prouctList = new List<Product>()
            {
                new Product(){Id=1,Name="Iphone 5s",Price=50000},
                new Product(){Id=2,Name="Iphone 7",Price=75000},
                new Product(){Id=3,Name="Samsung s7",Price=87000},
            };

           // return new JsonResult(prouctList);  //worked
            return Json(prouctList);
        }



        [HttpPost]
        public JsonResult Create(Employee employee)
        {

            var EmpSaved = new Employee()
            {
                 Id=employee.Id,
                 Name=employee.Name,
                 Address=employee.Address
            };

            var result = new { Status = true, SavedEmp = EmpSaved };

            //return Json(new { Status = true, SavedEmp = EmpSaved });   // Worked...

            return Json(result);
        }
    }
}
