using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RobsDerbyCars.Controllers
{
    public class RaceIdeasController : Controller
    {
        // GET: RaceIdeas
        public ActionResult Index()
        {
            ViewBag.Label = "The Race Ideas page is under construction.";
            ViewBag.Message = "This view will have information and ideas you may want to consider using to help your Royal Ranger Outpost or Scout Pack have a memorable fun race.";
            return View();
        }
    }
}