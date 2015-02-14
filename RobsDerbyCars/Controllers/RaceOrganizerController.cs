using RobsDerbyCars.DAL;
using RobsDerbyCars.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RobsDerbyCars.Controllers
{
    public class RaceOrganizerController : Controller
    {
        private DerbyContext db = new DerbyContext();

        // GET: RaceOrganizer
        public ActionResult Index()
        {
            ViewBag.Label = "The Race Organizer page is under construction.";
            ViewBag.Message = "This view will allow the Pinewood Derby race coordinator to set up a race with the names of all the race participants. It will then create all the heats for the race and calculate the winners when the race is complete. ";


            return View(db.Racers.ToList());
        }
  
        
//************************************************************************************************************************
// AddRacer
//************************************************************************************************************************
        // GET: Racer/Create
        public ActionResult AddRacers()
        {
            return View();
        }



        // POST: Racer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddRacers([Bind(Include = "RacerID,FirstName,LastName,Age,Division")] Racer racer)
        {
            if (ModelState.IsValid)
            {
                db.Racers.Add(racer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(racer);
        }

//************************************************************************************************************************
// EditRacer
//************************************************************************************************************************     

        // GET
        public ActionResult EditRacer(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Racer racer = db.Racers.Find(id);
            if (racer == null)
            {
                return HttpNotFound();
            }
            return View(racer);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditRacer([Bind(Include = "RacerID,FirstName,LastName,Age,Division")] Racer racer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(racer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(racer);
        }


//************************************************************************************************************************
// RemoveRacer
//************************************************************************************************************************            

        // GET
        public ActionResult RemoveRacer(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Racer racer = db.Racers.Find(id);
            if (racer == null)
            {
                return HttpNotFound();
            }
            return View(racer);
        }

        // POST
        [HttpPost, ActionName("RemoveRacer")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Racer racer = db.Racers.Find(id);
            db.Racers.Remove(racer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


//*****************************************************************************************************************************


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }   
        
        
        
        
        
        
        
        /*/GET action
        public ActionResult AddRacers()
        {
            return View();

        }
        
        // POST Action
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RacerID,FirstName,LastName,Age,Division")] Racer racer)
        {
            if (ModelState.IsValid)
            {
                db.Racers.Add(racer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(racer);
        }*/
    }
}