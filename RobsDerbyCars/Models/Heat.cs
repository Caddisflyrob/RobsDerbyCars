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
        public int RaceID { get; set; }
        public int FirstRacerID { get; set; }
        public int SecondRacerID { get; set; }
        public bool FirstRacerIsWinner { get; set; }
        public bool SecondRacerIsWinner { get; set; }
        public bool IsComplete { get; set; }
        public String Division { get; set; }
        public String FirstRacerName { get; set; }
        public String SecondRacerName { get; set; }
                
       //public virtual ICollection<Racer> Racers { get; set; }
    }
    
}
