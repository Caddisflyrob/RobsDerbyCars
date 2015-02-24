using RobsDerbyCars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobsDerbyCars.ViewModels
{
    public class CreateRaceVM
    {
        public int RaceID { get; set; }
        public String DivisionName { get; set; }
        public List<String> DivisionList { get; set; }

        public virtual ICollection<Heat> Heats { get; set; }
    }
}
