using RobsDerbyCars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RobsDerbyCars.DAL
{
    public class FakeUnitOfWork : IUnitOfWork
    {
        private IDerbyCars<Car> carRepo;
        private IDerbyCars<Comment> commentRepo;
       

        private List<Car> cars;
        private List<Comment> comments;
       

        public FakeUnitOfWork(List<Car> car = null, List<Comment> com = null)
        {
            if (car == null)
                cars = new List<Car>();
            else
                cars = car;

            if (com == null)
                comments = new List<Comment>();
            else
                comments = com;
       }

        public IDerbyCars<Models.Car> CarRepo
        {
            get
            {
                if (this.carRepo == null)
                {
                    this.carRepo = new FakeRobsDerbyCarsGenRepo<Car>(cars);
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
                    this.commentRepo = new FakeRobsDerbyCarsGenRepo<Comment>(comments);
                }
                return commentRepo;
            }
        }

        public void Save()
        {
            // Nothing to do here
        }

        public void Dispose()
        {
            // Nothing to do here
        }
    }
}