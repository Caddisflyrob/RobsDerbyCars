﻿using RobsDerbyCars.DAL;
using RobsDerbyCars.Models;
using RobsDerbyCars.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RobsDerbyCars.Controllers
{
   
    public class GalleryController : Controller
    {
       private DerbyContext db = new DerbyContext();
       private static int ThisID = 0;

//Index *************************************************************************************
        // GET: Car
        public ActionResult Index()
        {
            return View(db.Cars.ToList());
        }


//Detail ************************************************************************************

        public ActionResult Detail(int? id)
        {
            if (id == null)     // if no id was passed
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car= db.Cars.Find(id);
            if(car == null)
            {
                return HttpNotFound();
            }

            var AllComments = db.Comments.ToList();

            foreach (var thisCarsComment in AllComments)
                if (thisCarsComment.CarIdNum == car.CarID)
                    car.comments.Add(thisCarsComment);
           
            return View(car);
            }


//Add Comments********************************************************************************
        // GET
        public ActionResult AddComment(int? id)
        {
            
            if (id == null)     // if no id was passed
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            ThisID = car.CarID;
            ViewBag.CarName = car.CarName;
            ViewBag.Owner = car.Owner;
            ViewBag.PictureURL = car.PictureURL;
            ViewBag.CarDescription = car.Description;
            return View();
        }


        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddComment([Bind(Include = "Name,CommentText, CarIDNum")] Comment comment)  //remove Comment ID & CarID
        {

           if (ModelState.IsValid)
            {
                Car car = db.Cars.Find(ThisID);
                comment.CarIdNum = ThisID;
                db.Comments.Add(comment);
                db.SaveChanges();
               return RedirectToAction("Index");
               //return RedirectToAction("Detail", car.CarID);
            }

            return View(comment);
        }


//CarOwners *********************************************************************************

        public ActionResult CarOwners()
        {
            IQueryable<CarOwners> data = from car in db.Cars
                                                   group car by car.Owner  into ownerGroup
                                                   select new CarOwners()
                                                   {
                                                       Owner = ownerGroup.Key,
                                                       CarCount = ownerGroup.Count()
                                                   };
            return View(data.ToList());
        }

/*/Dispose ***********************************************************************************

protected override void Dispose(bool disposing)
{
    db.Dispose();
    base.Dispose(disposing);
}


/* BookInfoContext db = new BookInfoContext();
            var books = (from b in db.Books                //LINQ 
                         select b);
            return View(books); 
*/ 
    }
}