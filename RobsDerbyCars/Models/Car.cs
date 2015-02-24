using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RobsDerbyCars.Models
{
    public class Car
    {
        public int CarID { get; set; }

        [StringLength(35, ErrorMessage = "The Car's name cannot be longer than 35 characters.")]
        public string CarName { get; set; }
        public string PictureURL { get; set; }
        public string ThumbnailURL { get; set; }
        public string Description { get; set; }

        [StringLength(30, ErrorMessage = "The Owner's name cannot be longer than 30 characters.")]
        public string Owner { get; set; }

        public virtual ICollection<Comment> comments { get; set; }
    }
}