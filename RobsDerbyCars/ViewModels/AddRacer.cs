using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobsDerbyCars.ViewModels
{
    public class AddRacer
    {
        public int RacerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Division { get; set; }
        public int NumWins { get; set; }
        //public List<string> DivisionsList { get; set; }
    }
}
