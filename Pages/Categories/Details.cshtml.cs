using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Mehno_Gavril_Volunteers.Data;
using Mehno_Gavril_Volunteers.Models;

namespace Mehno_Gavril_Volunteers.Pages.Categories
{
    public class DetailsModel : PageModel
    {
        private readonly Mehno_Gavril_Volunteers.Data.Mehno_Gavril_VolunteersContext _context;

        public DetailsModel(Mehno_Gavril_Volunteers.Data.Mehno_Gavril_VolunteersContext context)
        {
            _context = context;
        }

        public Category Category { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category = await _context.Category.FirstOrDefaultAsync(m => m.ID == id);

            if (Category == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
