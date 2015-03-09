using RobsDerbyCars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RobsDerbyCars.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private DerbyContext context = new DerbyContext();
        private IDerbyCars<Car> carRepo;
        private IDerbyCars<Comment> commentRepo;
       


        public IDerbyCars<Models.Car> CarRepo
        {
            get
            {
                if (this.carRepo == null)
                {
                    this.carRepo = new RobsDerbyCarsGenRepo<Car>(context);
                }
                return carRepo;
            }
        }

        public IDerbyCars<Models.Comment> CommentRepo
        {
            get
            {
                if (this.commentRepo == null)
                {
                    this.commentRepo = new RobsDerbyCarsGenRepo<Comment>(context);
                }
                return commentRepo;
            }
        }

         public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}