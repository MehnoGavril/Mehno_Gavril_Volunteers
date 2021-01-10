using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mehno_Gavril_Volunteers.Models
{
    public class VolunteerData
    {
        public IEnumerable<Volunteer> Volunteers { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<VolunteerCategory> VolunteerCategories { get; set; }
    }
}
