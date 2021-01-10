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
    public class DetailsModel : PageModel
    {
        private readonly Mehno_Gavril_Volunteers.Data.Mehno_Gavril_VolunteersContext _context;

        public DetailsModel(Mehno_Gavril_Volunteers.Data.Mehno_Gavril_VolunteersContext context)
        {
            _context = context;
        }

        public Volunteer Volunteer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Volunteer = await _context.Volunteer.FirstOrDefaultAsync(m => m.ID == id);

            if (Volunteer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
