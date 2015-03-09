using RobsDerbyCars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobsDerbyCars.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        IDerbyCars<Car> CarRepo { get; }
        IDerbyCars<Comment> CommentRepo { get; }
   
        void Save();
    }
}
