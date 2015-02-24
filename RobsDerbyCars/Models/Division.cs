using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobsDerbyCars.Models
{
    public class Division
    {
        public int DivisionID { get; set; }

        [StringLength(30, ErrorMessage = "The Division name cannot be longer than 30 characters.")]
        public String DivisionName { get; set; }
        public String PreviousDivisionName { get; set; }
    }
}
