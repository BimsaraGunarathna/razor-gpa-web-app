using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using razor_gpa_web_app.Data;
using razor_gpa_web_app.Models;

namespace razor_gpa_web_app.Pages.Degrees
{
    public class EditModel : DepartmentNamePageModel
    {
        private readonly razor_gpa_web_app.Data.DBContext _context;

        public EditModel(razor_gpa_web_app.Data.DBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Degree Degree { get; set; }

        public async Task<IActionResult> OnGetAsync(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Degree = await _context.Degree
                .Include(d => d.Department)
                .FirstOrDefaultAsync(m => m.DegreeID == id);

            if (Degree == null)
            {
                return NotFound();
            }
            // Select current DepartmentID.
            PopulateDepartmentsDropDownList(_context, Degree.DepartmentID);
            //ViewData["DepartmentID"] = new SelectList(_context.Set<Department>(), "DepartmentID", "DepartmentID");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var courseToUpdate = await _context.Degree.FindAsync(id);

            if (courseToUpdate == null)
            {
                return NotFound();
            }
            /*
            if (await TryUpdateModelAsync<Degree>(
                 courseToUpdate,
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
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            */
            await TryUpdateModelAsync<Degree>(
                 courseToUpdate,
                 "degree",   // Prefix for form value.
                 //s => s.DegreeID,
                 s => s.DegreeName,
                 s => s.FacultyName,
                 s => s.DegreeCode,
                 s => s.NumOfYears,
                 s => s.DepartmentID,
                 s => s.DepartmentName
            );
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
            // Select DepartmentID if TryUpdateModelAsync fails.
            //PopulateDepartmentsDropDownList(_context, courseToUpdate.DepartmentID);
            //return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        /*
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Degree).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DegreeExists(Degree.DegreeID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }
        

        private bool DegreeExists(string id)
        {
            return _context.Degree.Any(e => e.DegreeID == id);
        }
        */
    }
}
