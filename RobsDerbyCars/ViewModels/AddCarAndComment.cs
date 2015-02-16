using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RobsDerbyCars.ViewModels
{
    public class AddCarAndComment
    {
        public string Name { get; set; }
        public string CommentText { get; set; }
          
        public string CarName { get; set; }
        public string PictureURL { get; set; }
        public string ThumbnailURL { get; set; }
        public string Description { get; set; }
        public string Owner { get; set; }
    }
}