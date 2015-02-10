using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RobsDerbyCars.Models
{
    public class Comment
    {
        public int CommentID { get; set; }
        public string Name { get; set; }
        public string CommentText{ get; set; }
        public int CarIdNum { get; set; }
                        
    }
}