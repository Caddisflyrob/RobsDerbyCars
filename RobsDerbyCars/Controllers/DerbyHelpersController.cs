using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RobsDerbyCars.Controllers
{
    public class DerbyHelpersController : Controller
    {
        // GET: DerbyHelpers
        public ActionResult Index()
        {
            ViewBag.Label = "The Derby Helpers page is under construction.";
            ViewBag.Message = "This view will have information links to files that will help you to setup and prepair for a great race.";
            return View();
        }
    }
}