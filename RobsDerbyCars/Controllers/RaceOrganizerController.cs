using RobsDerbyCars.DAL;
using RobsDerbyCars.Models;
using RobsDerbyCars.ViewModels;
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
        static int ID;

        //************************************************************************************************************************
        // index 
        //************************************************************************************************************************
        public ActionResult Index()
        {
            ViewBag.Label = "The Race Organizer page is under construction.";
            ViewBag.Message = "This view will allow the Pinewood Derby race coordinator to set up a race with the names of all the race participants. It will then create all the heats for the race and calculate the winners when the race is complete. ";

            RaceOrganizerIndexVM ROIVM = new RaceOrganizerIndexVM();

            List<Division> myDivisionList = db.Divisions.ToList();
            ROIVM.divisionList = myDivisionList;
            //ROIVM.divisionList = GetDivisionNamesList();

            List<Racer> RacerList = db.Racers.ToList();
            ROIVM.racerList = RacerList;

            return View(ROIVM);
        }
        //************************************************************************************************************************
        // Race a Heat
        //************************************************************************************************************************
        // GET: 
        public ActionResult RaceAHeat(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Heat heat = db.Heats.Find(id);
            if (heat == null)
            {
                return HttpNotFound();
            }
            heat.SecondRacerIsWinner=false;
            heat.FirstRacerIsWinner = false;
            heat.IsComplete = false;
            return View(heat);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RaceAHeat([Bind(Include = "HeatID, RaceID, Division, FirstRacerID, SecondRacerID, FirstRacerName, SecondRacerName, FirstRacerIsWinner, SecondRacerIsWinner, IsComplete")] Heat heat)
        {
            if (heat.FirstRacerIsWinner)
                heat.SecondRacerIsWinner = false;
            else
                heat.SecondRacerIsWinner = true;


            int ID = 0;
            if (ModelState.IsValid)
            {
                if (heat.FirstRacerIsWinner || heat.SecondRacerIsWinner)
                    heat.IsComplete = true;
                db.Entry(heat).State = EntityState.Modified;
                db.SaveChanges();

                foreach (var div in db.Divisions)
                    if (div.DivisionName == heat.Division)
                        ID = div.DivisionID;

                return RedirectToAction("ShowRace", "RaceOrganizer", new { id = ID });
            }
            return View(heat);
        }


        //************************************************************************************************************************
        // Select a race
        //************************************************************************************************************************
        public ActionResult SelectARace()
        //GET
        {
            ViewBag.DivisionList = GetDivisionNamesList();
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SelectARace([Bind(Include = "DivisionName")] Division division)
        {
            int ID = 0;
            foreach(var d in db.Divisions)
                if (division.DivisionName == d.DivisionName)
                     ID = d.DivisionID;
            //ViewBag.DivisionName = division.DivisionName;
            return RedirectToAction("ShowRace", "RaceOrganizer", new { id = ID });
        }
         

        //************************************************************************************************************************
        // Show a race with all the heats ready to be updated
        //************************************************************************************************************************
       
        public ActionResult ShowRace(int? id)
        {
            string ThisDivName = "";
            List<Heat> HeatList =new List<Heat>();
            

            foreach (Division d in db.Divisions)        //looks through all divisions for an ID match
            {
                if (d.DivisionID == id)
                    ThisDivName = d.DivisionName;       // gets the division name for the matching ID
            }

            foreach (Heat h in db.Heats)                //finds all the heats with a matching Division name
                if (h.Division == ThisDivName)
                    HeatList.Add(h);                    //adds the matching heats to a list

            ViewBag.Division = ThisDivName;
            var Heatlist = (from h in db.Heats where h.Division == ThisDivName select h);   //LINQ

            return View(HeatList);                      // An IEnumerable<RobsDerbyCars.Models.Heat>
        }  

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult ShowRace([Bind(Include = "HeatID,RaceID,Division, FirstRacerID, SecondRacerID,FirstRacerName,SecondRacerName,FirstRacerIsWinner, SecondRacerIsWinner, IsComplete")] IEnumerable<RobsDerbyCars.Models.Heat> formHeatList)
        public ActionResult ShowRace([Bind(Include = "HeatID,RaceID,Division, FirstRacerID, SecondRacerID,FirstRacerName,SecondRacerName,FirstRacerIsWinner, SecondRacerIsWinner, IsComplete")] Heat formHeat)
        
        {
            if (ModelState.IsValid)
            {
                //foreach (var formHeat in formHeat)
                //{
                    db.Entry(formHeat).State = EntityState.Modified;
                    db.SaveChanges();
                //}

                return RedirectToAction("Index");
            }

            return View(formHeat);
            //return View(formHeatList);
        }

        
        //************************************************************************************************************************
        // AddDivision
        //************************************************************************************************************************
        // GET
        public ActionResult AddDivision()
        {
            return View();
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddDivision([Bind(Include = "DivisionName")] Division division)
        {
            
            foreach (var div in db.Divisions)
                if (div.DivisionName == division.DivisionName)
                    return RedirectToAction("DuplicateDivision"); ;
                
            if (ModelState.IsValid)
            {
                db.Divisions.Add(division);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(division);
        }
        //************************************************************************************************************************
        // Duplicate Division Error
        //************************************************************************************************************************  
        public ActionResult DuplicateDivision()
        {
            return View();
        }

        //************************************************************************************************************************
        // Remove a Division
        //************************************************************************************************************************            

        // GET
        public ActionResult RemoveDivision(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Division div = db.Divisions.Find(id);
            if (div == null)
            {
                return HttpNotFound();
            }
            return View(div);
        }

        // POST
        [HttpPost, ActionName("RemoveDivision")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Division div = db.Divisions.Find(id);
            db.Divisions.Remove(div);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //************************************************************************************************************************
        // Edit a Division
        //************************************************************************************************************************     

        // GET
        public ActionResult EditDivision(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Division div = db.Divisions.Find(id);
            if (div == null)
            {
                return HttpNotFound();
            }
            div.PreviousDivisionName = div.DivisionName;
            if (ModelState.IsValid)
            {
                db.Entry(div).State = EntityState.Modified;
                db.SaveChanges();
            }

            return View(div);
        }

        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDivision([Bind(Include = "DivisionName, DivisionID, PreviousDivisionName")] Division div)
        {
            foreach (Racer r in db.Racers)
            {
                if (r.Division == div.PreviousDivisionName)  //used to change the division names for each Racer 
                {
                    r.Division = div.DivisionName;
                    if (ModelState.IsValid)
                    {
                        db.Entry(r).State = EntityState.Modified;
                        //db.SaveChanges();
                    }
                }
            }
            if (ModelState.IsValid)
            {
                db.Entry(div).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(div);

        }


        //************************************************************************************************************************
        // AddRacer
        //************************************************************************************************************************
        // GET
        public ActionResult AddRacers()
        {
            ViewBag.DivisionList = GetDivisionNamesList();
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
            ViewBag.DivisionList = GetDivisionNamesList();

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
        public ActionResult DeleteRacerConfirmed(int id)
        {
            Racer racer = db.Racers.Find(id);
            db.Racers.Remove(racer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //*****************************************************************************************************************************
        // ShowHeatsfor index list only
        //*****************************************************************************************************************************
        public ActionResult ShowHeats()
        {
            foreach (Heat h in db.Heats)         // Clears Heats from the DB
            {
                db.Heats.Remove(h);
            }
            db.SaveChanges();

            var myDivisionList = db.Divisions.ToList();

            foreach (var div in myDivisionList)
                CreateHeats(div.DivisionName);


            return View(db.Heats.ToList());
        }


        //*****************************************************************************************************************************
        // Create Heats  for index list only
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
                        thisHeat.FirstRacerID = racers[car1].RacerID;
                        thisHeat.FirstRacerName = racers[car1].FirstName + " " + racers[car1].LastName;
                        thisHeat.SecondRacerID = racers[car2].RacerID;
                        thisHeat.SecondRacerName = racers[car2].FirstName + " " + racers[car2].LastName;
                        thisHeat.Division = division;
                        db.Heats.Add(thisHeat);             //Add the this heat to the database
                        db.SaveChanges();                   // saves this heat to the DB
                    }
                }

        }
        //*****************************************************************************************************************************
        // Remove Heats from a single race
        //*****************************************************************************************************************************
        //GET
        public void ClearHeatsFromRace(string DivisionName )
        {
            foreach (var heat in db.Heats)
                if (heat.Division == DivisionName)
                {
                    db.Heats.Remove(heat);
                   
                }
        db.SaveChanges();
        }


        //*****************************************************************************************************************************
        // Fill a single Race with heats
        //*****************************************************************************************************************************
        //GET
        public ActionResult AddHeatsToRace( )
        {
            List<string> raceList = new List<string>();
            AddHeatsToRaceVM RD = new AddHeatsToRaceVM();
            
            foreach (var d in db.Divisions)                             //adds only races that have been created to the list of divisions
                raceList.Add(d.DivisionName);
            
            //foreach (var r in db.Races)                             //adds only races that have been created to the list of divisions
            //    raceList.Add(r.DivisionName);
            RD.DivisionList = raceList;                             // adds this list of races to the division list
                        
            return View(RD);
        }
        
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddHeatsToRace([Bind(Include = "RaceID, DivisionName, Heats")] AddHeatsToRaceVM thisRace)
        {

            int getRaceID = 0;

            if (ModelState.IsValid)
            {
                ClearHeatsFromRace(thisRace.DivisionName);          //clears old heats from the race
                
                foreach (var r in db.Races)
                    if (r.DivisionName == thisRace.DivisionName)    // get the Race ID that coisponds with this division name
                        getRaceID = r.RaceID;

                Heat thisHeat = new Heat();                         // create a new Heat Object
                var racers = db.Racers.ToList();

                for (int car1 = 0; car1 < racers.Count(); car1++)
                    for (int car2 = car1 + 1; car2 < racers.Count(); car2++)                            //loops through all the racers to set up the heats for this race
                    {
                        if (racers[car1].Division == thisRace.DivisionName && racers[car2].Division == thisRace.DivisionName)     // checks for both racers in the current division
                        {
                            thisHeat.FirstRacerID = racers[car1].RacerID;
                            thisHeat.FirstRacerName = racers[car1].FirstName + " " + racers[car1].LastName;
                            thisHeat.SecondRacerID = racers[car2].RacerID;
                            thisHeat.SecondRacerName = racers[car2].FirstName + " " + racers[car2].LastName;
                            thisHeat.Division = thisRace.DivisionName;
                            thisHeat.RaceID = getRaceID;
                            thisHeat.IsComplete = false;

                            db.Heats.Add(thisHeat);             //Add this heat to the database
                            db.SaveChanges();                   // saves this heat to the DB
                        }
                    }
                return RedirectToAction("Index");
            }
            return View(thisRace);
        }
        //*****************************************************************************************************************************
        // Create a Race  
        //*****************************************************************************************************************************
        // GET: 
        public ActionResult CreateRace()
        {
            CreateRaceVM CR = new CreateRaceVM();
            CR.DivisionList = GetDivisionNamesList();
            return View(CR);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateRace([Bind(Include = "RaceID, DivisionName, Heats")] CreateRaceVM CR)
        {
            if (ModelState.IsValid)
            {
                foreach (Race r in db.Races)                // Clears old Races for this division from the DB
                {
                    if (r.DivisionName == CR.DivisionName)  // check for old races with same division name
                        db.Races.Remove(r);                 // removes the old race
                }
                db.SaveChanges();                          
                
                foreach (Heat h in db.Heats)                // Clears old Heats for this division from the DB
                {
                    if (h.Division == CR.DivisionName)      // check for old Heats with same division name
                        db.Heats.Remove(h);                 // removes the old Heat
                }
                db.SaveChanges();                          


                Race thisRace = new Race();
                thisRace.DivisionName = CR.DivisionName;

                db.Races.Add(thisRace);             //Add the this race to the database
                db.SaveChanges();                   // saves this race to the DB


                //Fill a race with Heats
                //foreach (Race r in db.Races)
                //    if (r.DivisionName == CR.DivisionName)
                //        thisRace = r;

                //FillASingleRace(thisRace);

                return RedirectToAction("Index");
            }

            return View(CR);
        }



        //*****************************************************************************************************************************
        // Remove all Racers
        //*****************************************************************************************************************************
        // GET
        public ActionResult RemoveAllRacers()
        {
            var check4null = db.Racers.ToList();
            if (check4null.Count() == 0)
                ViewBag.IsEmpty = true;

            return View();
        }

        // POST
        [HttpPost, ActionName("RemoveAllRacers")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAllRacersConfirmed()
        {
            foreach (Racer r in db.Racers)         // Clears all racers from the DB
            {
                db.Racers.Remove(r);
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //*****************************************************************************************************************************
        // Remove all Divisions
        //*****************************************************************************************************************************

        // GET
        public ActionResult RemoveAllDivisions()
        {
            var check4null = db.Divisions.ToList();
            if (check4null.Count() == 0)
                ViewBag.IsEmpty = true;

            return View();
        }

        // POST
        [HttpPost, ActionName("RemoveAllDivisions")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAllDivisionsConfirmed()
        {
            foreach (Division d in db.Divisions)         // Clears all racers from the DB
            {
                db.Divisions.Remove(d);
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }



        //*****************************************************************************************************************************
        // Get a list of all Division Names
        //*****************************************************************************************************************************
        private List<string> GetDivisionNamesList()
        {
            var myDivisionList = db.Divisions.ToList();
            List<String> myList = new List<string>();
            foreach (var div in myDivisionList)
                myList.Add(div.DivisionName);
            return (myList);
        }

        //*****************************************************************************************************************************
        // Calculate and show Winner
        //*****************************************************************************************************************************
        public ActionResult ShowWinners(string div) //takes in a division name as string
        {
            div = "Sleepy Bunnies"; //for testing

            ShowWinnersVM SWVM = new ShowWinnersVM();
            int winnerId;
            string ThisDivName = "";
            List<Heat> HeatList = new List<Heat>();
            List<Racer> RacerList = new List<Racer>();
            int firstPlaceRacerID = 0;
            int secondPlaceRacerID = 0;
            int thirdPlaceRacerID = 0;
            int fourthPlaceRacerID = 0;
            int fifthPlaceRacerID = 0;
            int sixthPlaceRacerID = 0;
            int first = 0;
            int second = 0;
            int third = 0;
            int fourth = 0;
            int fifth = 0;
            int sixth = 0;

            
            ThisDivName = div;       // gets the division name for the matching ID
            

            foreach (Racer r in db.Racers)
            {
                if (r.Division == ThisDivName)           //clears all wins from racers in this division
                    r.NumWins = 0;
                RacerList.Add(r);
            }

            foreach (Heat h in db.Heats)                //finds all the heats with a matching Division name
                if (h.Division == ThisDivName)
                    HeatList.Add(h);                    //adds the matching heats to a list

            foreach (Heat h in HeatList)
            {
                if (h.FirstRacerIsWinner)                // gets the RacerID of thr winner for a heat
                    winnerId = h.FirstRacerID;
                else
                    winnerId = h.SecondRacerID;

                foreach (Racer r in RacerList)           // increments the number of wins for the winner of each heat
                    if (r.RacerID == winnerId)
                        r.NumWins++;
            }
            first = 0;
            second = 0;
            third = 0;
            fourth = 0;
            fifth = 0;
            sixth = 0;

            for (int x = RacerList.Count(); x > 0; x--)   //puts racers into positions based on number of wins
                foreach (Racer r in RacerList)
                    if (r.NumWins == x)
                        if (first == 0)
                        {
                            first = r.NumWins;
                            firstPlaceRacerID = r.RacerID;
                        }
                        else if (second == 0)
                        {
                            second = r.NumWins;
                            secondPlaceRacerID = r.RacerID;
                        }
                        else if (third == 0)
                        {
                            third = r.NumWins;
                            thirdPlaceRacerID = r.RacerID;
                        }
                        else if (fourth == 0)
                        {
                            fourth = r.NumWins;
                            fourthPlaceRacerID = r.RacerID;
                        }
                        else if (fifth == 0)
                        {
                            fifth = r.NumWins;
                            fifthPlaceRacerID = r.RacerID;
                        }
                        else if (sixth == 0)
                        {
                            sixth = r.NumWins;
                            sixthPlaceRacerID = r.RacerID;
                        }

            if (sixth == fifth && fifth != 0)               //check for two positions with same # of wins and check the heat for winner
            {
                foreach (Heat h in HeatList)      //look for heat with both racers
                    if ((h.FirstRacerID == fifthPlaceRacerID || h.FirstRacerID == sixthPlaceRacerID) && (h.SecondRacerID == fifthPlaceRacerID || h.SecondRacerID == sixthPlaceRacerID)) //finds a heat
                        if (h.FirstRacerIsWinner)
                        {
                            fifthPlaceRacerID = h.FirstRacerID;
                            sixthPlaceRacerID = h.SecondRacerID;
                        }
                        else
                        {
                            fifthPlaceRacerID = h.SecondRacerID;
                            sixthPlaceRacerID = h.FirstRacerID;
                        }
            }

            if (fifth == fourth && fifth != 0)               //check for two positions with same # of wins and check the heat for winner
            {
                foreach (Heat h in HeatList)      //look for heat with both racers
                    if ((h.FirstRacerID == fourthPlaceRacerID || h.FirstRacerID == fifthPlaceRacerID) && (h.SecondRacerID == fourthPlaceRacerID || h.SecondRacerID == fifthPlaceRacerID)) //finds a heat
                        if (h.FirstRacerIsWinner)
                        {
                            fourthPlaceRacerID = h.FirstRacerID;
                            fifthPlaceRacerID = h.SecondRacerID;
                        }
                        else
                        {
                            fourthPlaceRacerID = h.SecondRacerID;
                            fifthPlaceRacerID = h.FirstRacerID;
                        }
            }

            if (fourth == third && third != 0)               //check for two positions with same # of wins and check the heat for winner
            {
                foreach (Heat h in HeatList)      //look for heat with both racers
                    if ((h.FirstRacerID == thirdPlaceRacerID || h.FirstRacerID == fourthPlaceRacerID) && (h.SecondRacerID == thirdPlaceRacerID || h.SecondRacerID == fourthPlaceRacerID)) //finds a heat
                        if (h.FirstRacerIsWinner)
                        {
                            thirdPlaceRacerID = h.FirstRacerID;
                            fourthPlaceRacerID = h.SecondRacerID;
                        }
                        else
                        {
                            thirdPlaceRacerID = h.SecondRacerID;
                            fourthPlaceRacerID = h.FirstRacerID;
                        }
            }

            if (third == second && third != 0)               //check for two positions with same # of wins and check the heat for winner
            {
                foreach (Heat h in HeatList)      //look for heat with both racers
                    if ((h.FirstRacerID == secondPlaceRacerID || h.FirstRacerID == thirdPlaceRacerID) && (h.SecondRacerID == secondPlaceRacerID || h.SecondRacerID == thirdPlaceRacerID)) //finds a heat
                        if (h.FirstRacerIsWinner)
                        {
                            secondPlaceRacerID = h.FirstRacerID;
                            thirdPlaceRacerID = h.SecondRacerID;
                        }
                        else
                        {
                            secondPlaceRacerID = h.SecondRacerID;
                            thirdPlaceRacerID = h.FirstRacerID;
                        }
            }


            if (first == second)               //check for two positions with same # of wins and check the heat for winner
            {
                foreach (Heat h in HeatList)      //look for heat with both racers
                    if ((h.FirstRacerID == firstPlaceRacerID || h.FirstRacerID == secondPlaceRacerID) && (h.SecondRacerID == firstPlaceRacerID || h.SecondRacerID == secondPlaceRacerID)) //finds a heat
                        if (h.FirstRacerIsWinner)
                        {
                            firstPlaceRacerID = h.FirstRacerID;
                            secondPlaceRacerID = h.SecondRacerID;
                        }
                        else
                        {
                            firstPlaceRacerID = h.SecondRacerID;
                            secondPlaceRacerID = h.FirstRacerID;
                        }
            }

            //load the viewModel
            SWVM.DivisionName = ThisDivName;
            SWVM.FirstPlaceID = firstPlaceRacerID;
            SWVM.SecondPlaceID = secondPlaceRacerID;
            SWVM.ThirdPlaceID = thirdPlaceRacerID;

            foreach (Racer r in db.Racers)
            {
                if (r.RacerID == firstPlaceRacerID)
                    SWVM.FirstPlaceName = r.FirstName + " " + r.LastName;
                if (r.RacerID == secondPlaceRacerID)
                    SWVM.SecondPlaceName = r.FirstName + " " + r.LastName;
                if (r.RacerID == thirdPlaceRacerID)
                    SWVM.ThirdPlaceName = r.FirstName + " " + r.LastName;
            }

            return View(SWVM);
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

    }
}