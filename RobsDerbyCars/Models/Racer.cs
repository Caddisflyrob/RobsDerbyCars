﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RobsDerbyCars.Models
{
    public class Racer
    {
        public int RacerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Division { get; set; }
        public int NumWins { get; set; }

        //public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}