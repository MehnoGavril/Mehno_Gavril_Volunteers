using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mehno_Gavril_Volunteers.Data;
using Mehno_Gavril_Volunteers.Models;

namespace Mehno_Gavril_Volunteers.Pages.Publishers
{
    public class CreateModel : PageModel
    {
        private readonly Mehno_Gavril_Volunteers.Data.Mehno_Gavril_VolunteersContext _context;

        public CreateModel(Mehno_Gavril_Volunteers.Data.Mehno_Gavril_VolunteersContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Publisher Publisher { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Publisher.Add(Publisher);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
