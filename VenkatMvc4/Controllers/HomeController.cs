using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VenkatMvc4.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public string Index()
        {
            return "<b>Version of your MVC is: " + typeof(Controller).Assembly.GetName().Version.ToString() + "</b>";
        }
    }
}