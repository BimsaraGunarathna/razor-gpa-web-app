using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using razor_gpa_web_app.Data;
using razor_gpa_web_app.Models;

namespace razor_gpa_web_app.Pages.Degrees
{
    public class CreateModel : DepartmentNamePageModel
    {
        private readonly DBContext _context;

        public CreateModel(DBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulateDepartmentsDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public Degree Degree { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {

            var emptyCourse = new Degree();
            /*
            if (await TryUpdateModelAsync<Degree>(
                 emptyCourse,
                 "degree",   // Prefix for form value.
                 s => s.DegreeID, 
                 s => s.DegreeName, 
                 s => s.FacultyName, 
                 s => s.DegreeCode,
                 s => s.NumOfYears,
                 s => s.DepartmentID,
                 s => s.DepartmentName
                 ))
            {
                _context.Degree.Add(emptyCourse);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            */
            await TryUpdateModelAsync<Degree>(
                 emptyCourse,
                 "degree",   // Prefix for form value.
                 s => s.DegreeID,
                 s => s.DegreeName,
                 s => s.FacultyName,
                 s => s.DegreeCode,
                 s => s.NumOfYears,
                 s => s.DepartmentID,
                 s => s.DepartmentName
            );
            _context.Degree.Add(emptyCourse);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");

            // Select DepartmentID if TryUpdateModelAsync fails.
            PopulateDepartmentsDropDownList(_context, emptyCourse.DepartmentID);
            return Page();
        }
    }
}
