using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyect1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Enjoy changing products with";
            return View();
        }

        public ActionResult MyProducts()
        {
            return View();
        }
    }
}