using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RobsDerbyCars.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Rob's Derby Cars web site was created by Rob Callahan using C# ASP.NET with MVC.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Rob";

            return View();
        }
       
    }
}