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

        //************************************************************************************************************************
        // index
        //************************************************************************************************************************
        public ActionResult Index()
        {
            ViewBag.Label = "The Race Organizer page is under construction.";
            ViewBag.Message = "This view will allow the Pinewood Derby race coordinator to set up a race with the names of all the race participants. It will then create all the heats for the race and calculate the winners when the race is complete. ";


            return View(db.Racers.ToList());
        }


        //************************************************************************************************************************
        // AddRacer
        //************************************************************************************************************************
        // GET
        public ActionResult AddRacers()
        {
            return View();
        }



        // POST
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
        // ShowHeats
        //*****************************************************************************************************************************
        public ActionResult ShowHeats()
        {
            
            foreach (Heat h in db.Heats)         // Clears Heats from the DB
            {
                db.Heats.Remove(h);
            }
            db.SaveChanges();

            CreateHeats("Expedition Rangers");
            CreateHeats("Adventure Rangers");
            CreateHeats("Discovery Rangers");
            CreateHeats("Ranger Kids");
            CreateHeats("Adult");

            return View(db.Heats.ToList());
        }



        //*****************************************************************************************************************************
        // CreateHeats
        //*****************************************************************************************************************************
        public void CreateHeats(string division)
        {
          Heat thisHeat = new Heat();
            var racers = db.Racers.ToList();


            for (int car1 = 0; car1 < racers.Count(); car1++)
                for (int car2 = car1 + 1; car2 < racers.Count(); car2++)
                {
                    if (racers[car1].Division == division && racers[car2].Division == division)
                    {
                        thisHeat.FirstRacer = racers[car1].RacerID;
                        thisHeat.FirstRacerName = racers[car1].FirstName + " " + racers[car1].LastName;
                        thisHeat.SecondRacer = racers[car2].RacerID;
                        thisHeat.SecondRacerName = racers[car2].FirstName + " " + racers[car2].LastName;
                        thisHeat.Division = division;
                        db.Heats.Add(thisHeat);             //Add the this heat to the database
                        db.SaveChanges();                   // saves this heat to the DB
                    }
                }

            
            /* 
            Heat thisHeat = new Heat();
            //var racers = db.Racers.ToList();
            IQueryable<Racer> racersInDivlist = from r in db.Racers where r.Division == division select new Racer();  //LINQ gets a collection of all racers in a division 
            
            Racer[] racersInDiv = new Racer[racersInDivlist.Count()]; //creates an array of Racer objects 
            int counter=0;
            foreach (Racer r in racersInDivlist)   //fills the Array with each racer in the collection
                 racersInDiv[counter++] = r;
            
            for (int car1=1; car1<racersInDiv.Count(); car1++)
                for (int car2 = car1 + 1; car2 <= racersInDiv.Count(); car2++)
                {
                    thisHeat.FirstRacer = racersInDiv[car1].RacerID;
                    thisHeat.SecondRacer = racersInDiv[car2].RacerID;
                    db.Heats.Add(thisHeat);                                 //Add the this heat to the database
                }
            db.SaveChanges();        //when all the heats have been added, they are saved to the DB
           */

        }


        //*****************************************************************************************************************************
        // Remove all Racers
        //*****************************************************************************************************************************
        public ActionResult RemoveAllRacers()
        {
            foreach (Racer r in db.Racers)         // Clears all racers from the DB
            {
                db.Racers.Remove(r);
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

                   
            
        





        //******************************************************************************************************************************
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