using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using razor_gpa_web_app.Areas.Identity.Data;
using razor_gpa_web_app.Data;
using razor_gpa_web_app.Models;

namespace razor_gpa_web_app.Pages.Grades
{
    public class EditModel : PageModel
    {
        private readonly razor_gpa_web_app.Data.DBContext _context;

        public EditModel(razor_gpa_web_app.Data.DBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Grade Grade { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Grade = await _context.Grade
                .Include(g => g.ApplicationUser)
                .Include(g => g.Degree)
                .Include(g => g.GPA)
                .Include(g => g.Semester)
                .Include(g => g.SubjectModule).FirstOrDefaultAsync(m => m.GradeID == id);

            if (Grade == null)
            {
                return NotFound();
            }
           ViewData["StudentID"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id");
           ViewData["DegreeID"] = new SelectList(_context.Degree, "DegreeID", "DegreeID");
           ViewData["GPAID"] = new SelectList(_context.GPA, "GPAID", "GPAID");
           ViewData["SemesterID"] = new SelectList(_context.Set<Semester>(), "SemesterID", "SemesterID");
           ViewData["SubjectModuleID"] = new SelectList(_context.Set<SubjectModule>(), "SubjectModuleID", "SubjectModuleID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Grade).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GradeExists(Grade.GradeID))
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

        private bool GradeExists(string id)
        {
            return _context.Grade.Any(e => e.GradeID == id);
        }
    }
}
