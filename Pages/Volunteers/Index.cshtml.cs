using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mehno_Gavril_Volunteers.Data;
using Mehno_Gavril_Volunteers.Models;

namespace Mehno_Gavril_Volunteers.Pages.Volunteers
{
    public class IndexModel : PageModel
    {
        private readonly Mehno_Gavril_Volunteers.Data.Mehno_Gavril_VolunteersContext _context;

        public IndexModel(Mehno_Gavril_Volunteers.Data.Mehno_Gavril_VolunteersContext context)
        {
            _context = context;
        }

        public IList<Volunteer> Volunteer { get;set; }

        public VolunteerData VolunteerD { get; set; }
        public int VolunteerID { get; set; }
        public int CategoryID { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID)
        {
            VolunteerD = new VolunteerData();

            VolunteerD.Volunteers = await _context.Volunteer
            .Include(b => b.Publisher)
            .Include(b => b.VolunteerCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.Name)
            .ToListAsync();
            if (id != null)
            {
                VolunteerID = id.Value;
                Volunteer volunteer = VolunteerD.Volunteers
                .Where(i => i.ID == id.Value).Single();
                VolunteerD.Categories = volunteer.VolunteerCategories.Select(s => s.Category);
            }
        }

    }
}
