using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mehno_Gavril_Volunteers.Data;


namespace Mehno_Gavril_Volunteers.Models
{
    public class VolunteerCategoriesPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(Mehno_Gavril_VolunteersContext context,
        Volunteer volunteer)
        {
            var allCategories = context.Category;
            var volunteerCategories = new HashSet<int>(
            volunteer.VolunteerCategories.Select(c => c.VolunteerID));
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = volunteerCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateVolunteerCategories(Mehno_Gavril_VolunteersContext context,
        string[] selectedCategories, Volunteer volunteerToUpdate)
        {
            if (selectedCategories == null)
            {
                volunteerToUpdate.VolunteerCategories = new List<VolunteerCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var volunteerCategories = new HashSet<int>
            (volunteerToUpdate.VolunteerCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!volunteerCategories.Contains(cat.ID))
                    {
                        volunteerToUpdate.VolunteerCategories.Add(
                        new VolunteerCategory
                        {
                            VolunteerID = volunteerToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (volunteerCategories.Contains(cat.ID))
                    {
                        VolunteerCategory courseToRemove
                        = volunteerToUpdate
                        .VolunteerCategories
                        .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }

    }
}
