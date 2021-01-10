using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mehno_Gavril_Volunteers.Models
{
    public class VolunteerCategory
    {
        public int ID { get; set; }
        public int VolunteerID { get; set; }
        public Volunteer Volunteer { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
