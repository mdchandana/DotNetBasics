using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http; // Needed for the SetString and GetString extension methods
using DotnetCoreSession.Models;

namespace DotnetCoreSession.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //======================
            /*
              now find the session object by using HttpContext.Session
              HttpContext is just the current HttpContext exposed to you by the Controller class.
              If you’re not in a controller, you can still access the HttpContext by injecting IHttpContextAccessor

              HttpContext.Session.SetString("MyName","Chandana Priyantha");
              ViewBag.MyName= HttpContext.Session.GetString("MyName");
            */

            var product1 = new Product()
            {
                Id=1,
                Name="IPhone 5s",
                Price=50000.00M
            };

            HttpContext.Session.SetObjectAsJson("phone", product1);
            //====================


            return View();
        }




        [HttpGet]
        public JsonResult GetProductFromSession()
        {
            //get product from session
            var productFromSession = HttpContext.Session.GetObjectFromJson<Product>("phone");

            return Json(productFromSession);
        }



        [HttpPost]
        public JsonResult AddToCart(Product product)
        {



            return Json("");
        }




    }
}
