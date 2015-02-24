using RobsDerbyCars.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobsDerbyCars.ViewModels
{
    public class ShowRaceVM
    {
        public List<Heat> HeatList { get; set; }
        public string DivisionName { get; set; }
    }
}
