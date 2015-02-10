using RobsDerbyCars.DAL;
using RobsDerbyCars.Models;
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

        // GET: Car
        public ActionResult Index()
        {
            return View(db.Cars.ToList());
        }

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
            return View(car);
    
        }

    }
}



/* BookInfoContext db = new BookInfoContext();
            var books = (from b in db.Books                //LINQ 
                         select b);
            return View(books); 
*/