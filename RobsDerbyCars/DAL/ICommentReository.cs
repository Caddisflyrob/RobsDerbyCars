using RobsDerbyCars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobsDerbyCars.DAL
{
    public interface ICommentReository: IDisposable
    {
        IEnumerable<Comment> GetComments();
        Comment GetCommentByID(int CommentId);
        void InsertComment(Comment comment);
        void DeleteComment(int commentID);
        void UpdateComment(Comment comment);
        void Save();
    }
}
