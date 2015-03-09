using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RobsDerbyCars.Models
{
    public class Race //: IEntityModel
    {
        public int RaceID { get; set; }
        public String DivisionName { get; set; }

        public virtual ICollection<Heat> Heats { get; set; }
    }
}