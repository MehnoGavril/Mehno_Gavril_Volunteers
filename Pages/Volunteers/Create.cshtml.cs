using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Mehno_Gavril_Volunteers.Data;
using Mehno_Gavril_Volunteers.Models;


namespace Mehno_Gavril_Volunteers.Pages.Volunteers
{
    public class CreateModel : VolunteerCategoriesPageModel
    {
        private readonly Mehno_Gavril_Volunteers.Data.Mehno_Gavril_VolunteersContext _context;

        public CreateModel(Mehno_Gavril_Volunteers.Data.Mehno_Gavril_VolunteersContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID", "PublisherName");
            var volunteer = new Volunteer();
            volunteer.VolunteerCategories = new List<VolunteerCategory>();
            PopulateAssignedCategoryData(_context, volunteer);
            return Page();
        }

        [BindProperty]
        public Volunteer Volunteer { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newVolunteer = new Volunteer();
            if (selectedCategories != null)
            {
                newVolunteer.VolunteerCategories = new List<VolunteerCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new VolunteerCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newVolunteer.VolunteerCategories.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Volunteer>( newVolunteer, "Volunteer", i => i.Name, i => i.Department, i => i.Occupation, i => i.EntryDate, i => i.PublisherID))
            {
                _context.Volunteer.Add(newVolunteer);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateAssignedCategoryData(_context, newVolunteer);
            return Page();
        }

    }
}
