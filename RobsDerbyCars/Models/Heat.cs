using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobsDerbyCars.Models
{
    public class Heat
    {
        
        public int HeatID { get; set; }
        public int FirstRacer { get; set; }
        public int SecondRacer { get; set; }
        public bool FirstRacerIsWinner { get; set; }
        public bool IsComplete { get; set; }
                
       public virtual ICollection<Racer> Racers { get; set; }
    }
    
}
