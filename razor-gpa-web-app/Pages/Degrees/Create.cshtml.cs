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
        private readonly razor_gpa_web_app.Data.DBContext _context;

        public CreateModel(razor_gpa_web_app.Data.DBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["DepartmentID"] = new SelectList(_context.Set<Department>(), "DepartmentID", "DepartmentID");
            PopulateDepartmentsDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public Degree Degree { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            //
            var emptyCourse = new Degree();

            if (await TryUpdateModelAsync<Degree>(
                 emptyCourse,
                 "degree",   // Prefix for form value.
                 s => s.DegreeID, s => s.DepartmentID, s => s.DegreeName, s => s.DegreeCode))
            {
                _context.Degree.Add(emptyCourse);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            // Select DepartmentID if TryUpdateModelAsync fails.
            PopulateDepartmentsDropDownList(_context, emptyCourse.DepartmentID);
            return Page();
            //

            /*
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Degree.Add(Degree);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
            */
        }
    }
}
