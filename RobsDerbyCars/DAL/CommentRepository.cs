using RobsDerbyCars.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RobsDerbyCars.DAL
{
    public class CommentRepository :ICommentReository, IDisposable
    {
        private DerbyContext context;

        public CommentRepository(DerbyContext context)
        {
            this.context = context;
        }

        public IEnumerable<Comment> GetComments()
        {
            return context.Comments.ToList();
        }

        public Comment GetCommentByID(int id)
        {
            return context.Comments.Find(id);
        }

        public void InsertComment(Comment comment)
        {
            context.Comments.Add(comment);
        }

        public void DeleteComment(int commentID)
        {
            Comment comment = context.Comments.Find(commentID);
            context.Comments.Remove(comment);
        }

        public void UpdateComment(Comment comment)
        {
            context.Entry(comment).State = EntityState.Modified;
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
