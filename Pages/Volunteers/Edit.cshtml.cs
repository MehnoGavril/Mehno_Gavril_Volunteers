using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mehno_Gavril_Volunteers.Data;
using Mehno_Gavril_Volunteers.Models;


namespace Mehno_Gavril_Volunteers.Pages.Volunteers
{
    public class EditModel : VolunteerCategoriesPageModel
    {
        private readonly Mehno_Gavril_Volunteers.Data.Mehno_Gavril_VolunteersContext _context;

        public EditModel(Mehno_Gavril_Volunteers.Data.Mehno_Gavril_VolunteersContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Volunteer Volunteer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Volunteer = await _context.Volunteer
            .Include(b => b.Publisher)
            .Include(b => b.VolunteerCategories).ThenInclude(b => b.Category)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.ID == id);

            if (Volunteer == null)
            {
                return NotFound();
            }

            PopulateAssignedCategoryData(_context, Volunteer);

            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID", "PublisherName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var volunteerToUpdate = await _context.Volunteer
            .Include(i => i.Publisher)
            .Include(i => i.VolunteerCategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (volunteerToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Volunteer>(volunteerToUpdate, "Volunteer", i => i.Name, i => i.Department, i => i.Occupation, i => i.Publisher)) ;
            //Apelam UpdateVolunteerCategories pentru a aplica informatiile din checkboxuri la entitatea Volunteers care
            //este editata
            {
                UpdateVolunteerCategories(_context, selectedCategories, volunteerToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateVolunteerCategories(_context, selectedCategories, volunteerToUpdate);
            PopulateAssignedCategoryData(_context, Volunteer);
            return Page();
        }
    }
}