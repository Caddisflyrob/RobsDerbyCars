using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RobsDerbyCars.Controllers
{
    public class RaceOrganizerController : Controller
    {
        // GET: RaceOrganizer
        public ActionResult Index()
        {
            ViewBag.Label = "The Race Organizer page is under construction.";
            ViewBag.Message = "This view will allow the Pinewood Derby race coordinator to set up a race with the names of all the race participants. It will then create all the heats for the race and calculate the winners when the race is complete. ";
            return View();
        }
    }
}