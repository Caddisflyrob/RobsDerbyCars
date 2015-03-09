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
    public class CommentController : Controller
    {
        //private DerbyContext db = new DerbyContext();
        private ICommentReository commentRepository;

        public CommentController()
        {
            this.commentRepository = new CommentRepository(new DerbyContext());
        }

        public CommentController(ICommentReository commentRep)
        {
            this.commentRepository = commentRep;
        }

        //************************************************************************************
        //Index
        //************************************************************************************
        // GET: Comment
        public ActionResult Index()
        {
            //return View(db.Comments.ToList());
            return View(commentRepository.GetComments());
        }


        //************************************************************************************
        //Detail
        //************************************************************************************
        // GET: Comment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Comment comment = db.Comments.Find(id);
            Comment comment = commentRepository.GetCommentByID((int)id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }


        //************************************************************************************
        //Create
        //************************************************************************************
        // GET: Comment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CommentID,Name,CommentText,CarIDNum")] Comment comment)
        {
            //comment.CarIdNum = id;

            if (ModelState.IsValid)
            {
                //db.Comments.Add(comment);
                //db.SaveChanges();
                commentRepository.InsertComment(comment);
                commentRepository.Save();

                return RedirectToAction("Index");
            }

            return View(comment);
        }


        //************************************************************************************
        //Edit
        //************************************************************************************
        // GET: Comment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Comment comment = db.Comments.Find(id);
            Comment comment = commentRepository.GetCommentByID((int)id);

            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Comment/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CommentID,Name,CommentText,CarIdNum")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(comment).State = EntityState.Modified;
                //db.SaveChanges();
                commentRepository.UpdateComment(comment);
                commentRepository.Save();

                return RedirectToAction("Index");
            }
            return View(comment);
        }


        //************************************************************************************
        //Delete
        //************************************************************************************
        // GET: Comment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Comment comment = db.Comments.Find(id);
            Comment comment = commentRepository.GetCommentByID((int)id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Comment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Comment comment = db.Comments.Find(id);
            //db.Comments.Remove(comment);
            //db.SaveChanges();
            Comment comment = commentRepository.GetCommentByID((int)id);
            
                                            //List<Comment> ComList = commentRepository.GetComments().ToList();  //DELETE
                                            //foreach (var c in ComList)                                         //DELETE
                                            //commentRepository.DeleteComment((int)c.CommentID);                 //DELETE
            
            commentRepository.DeleteComment((int)id);
            commentRepository.Save();
            return RedirectToAction("Index");
        }


        //************************************************************************************
        //Dispose
        //************************************************************************************
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
                commentRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
