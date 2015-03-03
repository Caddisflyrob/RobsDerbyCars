using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobsDerbyCars.ViewModels
{
    public class ShowWinnersVM
    {
        public string DivisionName { get; set; }

        public int FirstPlaceID { get; set; }
        public int SecondPlaceID { get; set; }
        public int ThirdPlaceID { get; set; }

        public string FirstPlaceName { get; set; }
        public string SecondPlaceName { get; set; }
        public string ThirdPlaceName { get; set; }

    }
}
