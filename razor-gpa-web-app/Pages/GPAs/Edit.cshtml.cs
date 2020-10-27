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

namespace razor_gpa_web_app.Pages.GPAs
{
    public class EditModel : PageModel
    {
        private readonly razor_gpa_web_app.Data.DBContext _context;

        public EditModel(razor_gpa_web_app.Data.DBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public GPA GPA { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GPA = await _context.GPA
                .Include(g => g.AcademicYear)
                .Include(g => g.ApplicationUser)
                .Include(g => g.Semester)
                .Include(g => g.SubjectModule).FirstOrDefaultAsync(m => m.GPAID == id);

            if (GPA == null)
            {
                return NotFound();
            }
           ViewData["AcademicYearID"] = new SelectList(_context.Set<AcademicYear>(), "AcademicYearID", "AcademicYearID");
           ViewData["StudentID"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id");
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

            _context.Attach(GPA).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GPAExists(GPA.GPAID))
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

        private bool GPAExists(string id)
        {
            return _context.GPA.Any(e => e.GPAID == id);
        }
    }
}
