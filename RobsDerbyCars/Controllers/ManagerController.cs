using RobsDerbyCars.DAL;
using RobsDerbyCars.Models;
using RobsDerbyCars.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RobsDerbyCars.Controllers
{
    public class ManagerController : Controller
    {
        //private DerbyContext db = new DerbyContext();
        private UnitOfWork uow = new UnitOfWork();
      
//Index********************************************************************************************************************
        public ActionResult Index()
        {
            return View();
        }

//AddCarAndComment*********************************************************************************************************
        //get
        public ActionResult AddCarAndComment()
        {
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddCarAndComment([Bind(Include = "Name,CommentText,CarName,PictureURL,ThumbnailURL,Description,Owner")] AddCarAndComment CaC)
        {
            Comment comment = new Comment();
            Car car = new Car();
            car.CarName = CaC.CarName;
            car.Owner = CaC.Owner;
            car.PictureURL = CaC.PictureURL;
            car.ThumbnailURL = CaC.ThumbnailURL;
            car.Description = CaC.Description;

            comment.CommentText = CaC.CommentText;
            comment.Name = CaC.Name;
            comment.CarIdNum = uow.CarCount + 1;
            //comment.CarIdNum = db.Cars.Count() + 1;


            if (ModelState.IsValid)
            {
                uow.CarRepo.Insert(car);
                uow.CommentRepo.Insert(comment);
                uow.Save();

                //db.Cars.Add(car);
                //db.Comments.Add(comment);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(car);
        }




    }
}