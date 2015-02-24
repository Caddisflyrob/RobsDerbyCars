using RobsDerbyCars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobsDerbyCars.ViewModels
{
    public class RaceOrganizerIndexVM
    {
        public List<Racer> racerList { get; set; }
        public List<Division> divisionList { get; set; }
        
        //public List<String> divisionList { get; set; }
        //public IEnumerable<RobsDerbyCars.Models.Racer> racerList { get; set; }
        //public IEnumerable<RobsDerbyCars.Models.Division> divisionList { get; set; }
    }
}
