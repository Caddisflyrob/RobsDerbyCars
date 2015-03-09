using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RobsDerbyCars.DAL;
using RobsDerbyCars.Models;

namespace RobsDerbyCars.Controllers
{
    public class CarController : Controller
    {
        //private DerbyContext db = new DerbyContext();
        private UnitOfWork uow = new UnitOfWork();

//*****************************************************************************************
//  Index
//****************************************************************************************
        // GET: Car
        public ActionResult Index()
        {
            //return View(db.Cars.ToList());
            return View(uow.CarRepo.Get());    //Unit of Work
        }

//*****************************************************************************************
//  Details
//****************************************************************************************
        // GET: Car/Details/5
        public ActionResult Details(int? id)
        {
            Car thisCar = new Car();   //Unit Of Work

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var carList = uow.CarRepo.Get(); //Unit Of Work


            foreach (Car c in carList)      //Unit Of Work
                if (c.CarID == id)
                    thisCar = c;
            if (thisCar == null)
            {
                return HttpNotFound();
            }

            return View(thisCar);

            //Car car = db.Cars.Find(id);
            //if (car == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(car);
        }
 //*****************************************************************************************
 //  Create
 //****************************************************************************************
        // GET: Car/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Car/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CarID,CarName,PictureURL,ThumbnailURL,Description,Owner")] Car car)
        {
            if (ModelState.IsValid)
            {
                //db.Cars.Add(car);
                //db.SaveChanges();
                uow.CarRepo.Insert(car);
                uow.Save();

                return RedirectToAction("Index");
            }

            return View(car);
        }
 //*****************************************************************************************
 //  Edit
 //****************************************************************************************
        // GET: Car/Edit/5
        public ActionResult Edit(int? id)
        {
            Car thisCar = new Car();   //Unit Of Work

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var carList = uow.CarRepo.Get(); //Unit Of Work

            foreach (Car c in carList)      //Unit Of Work
                if (c.CarID == id)
                    thisCar = c;
            if (thisCar == null)
            {
                return HttpNotFound();
            }
            return View(thisCar);

            //Car car = db.Cars.Find(id);
            //if (car == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(car);
        }

        // POST: Car/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CarID,CarName,PictureURL,ThumbnailURL,Description,Owner")] Car car)
        {
            if (ModelState.IsValid)
            {
                uow.CarRepo.Update(car);
                uow.Save();
                return RedirectToAction("Index");
            }
            return View(car);


            //if (ModelState.IsValid)
            //{
            //    db.Entry(car).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //return View(car);
        }

//*****************************************************************************************
//  Delete
//****************************************************************************************
        // GET: Car/Delete/5
        public ActionResult Delete(int? id)
        {
            Car thisCar = new Car();   //Unit Of Work

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var carList = uow.CarRepo.Get(); //Unit Of Work

            foreach (Car c in carList)      //Unit Of Work
                if (c.CarID == id)
                    thisCar = c;
            if (thisCar == null)
            {
                return HttpNotFound();
            }
            return View(thisCar);


            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Car car = db.Cars.Find(id);
            //if (car == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(car);
        }

        // POST: Car/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Car thisCar = new Car();   //Unit Of Work
            var carList = uow.CarRepo.Get(); //Unit Of Work

            foreach (Car c in carList)      //Unit Of Work                
                                                    
                 if (c.CarID == id)
                    thisCar = c;
                                                //uow.CarRepo.Delete(c);//DELETE 
            uow.CarRepo.Delete(thisCar);
            uow.Save();
            return RedirectToAction("Index");

            //Car car = db.Cars.Find(id);
            //db.Cars.Remove(car);
            //db.SaveChanges();
            //return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                uow.Dispose();
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
