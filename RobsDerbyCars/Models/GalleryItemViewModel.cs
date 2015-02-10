using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RobsDerbyCars.Models
{
    public class GalleryItemViewModel
    {
        public int CarID { get; set; }
        public string CarName { get; set; }
        public string PictureURL { get; set; }
        public string ThumbnailURL { get; set; }
        public string Description { get; set; }
        public string Owner { get; set; }

        public virtual ICollection<Comment> comments { get; set; }

    }
}