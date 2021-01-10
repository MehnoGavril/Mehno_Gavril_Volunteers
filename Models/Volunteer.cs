using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mehno_Gavril_Volunteers.Models
{
    public class Volunteer
    {
        public int ID { get; set; }

       [Required, StringLength(250, MinimumLength = 2)]

        [Display(Name = "Name and Surname")]
        public string Name { get; set; }
 
        public string Department { get; set; }
        public string Occupation { get; set; }

        [DataType(DataType.Date)]
        public DateTime EntryDate { get; set; }
        public int PublisherID { get; set; }

        public Publisher Publisher { get; set; }

        public ICollection<VolunteerCategory> VolunteerCategories { get; set; }
    }
}
