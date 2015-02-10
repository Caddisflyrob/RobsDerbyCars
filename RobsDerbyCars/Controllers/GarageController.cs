using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RobsDerbyCars.Controllers
{
    public class GarageController : Controller
    {
        // GET: Garage
        public ActionResult Index()
        {
            ViewBag.Label = "The garage is under construction.";
            ViewBag.Message = "This view will have information on how to build a pinewood derby car.";
            return View();
        }
    }
}