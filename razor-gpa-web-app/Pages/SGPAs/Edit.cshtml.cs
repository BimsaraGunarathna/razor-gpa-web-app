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

namespace razor_gpa_web_app.Pages.SGPAs
{
    public class EditModel : PageModel
    {
        private readonly razor_gpa_web_app.Data.AppDBContext _context;

        public EditModel(razor_gpa_web_app.Data.AppDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SGPA SGPA { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SGPA = await _context.SGPA
                .Include(s => s.Semester)
                .Include(s => s.Year).FirstOrDefaultAsync(m => m.SGPAID == id);

            if (SGPA == null)
            {
                return NotFound();
            }
           ViewData["SemesterID"] = new SelectList(_context.Semester, "SemesterID", "SemesterID");
           ViewData["YearID"] = new SelectList(_context.Year, "YearID", "YearID");
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

            _context.Attach(SGPA).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SGPAExists(SGPA.SGPAID))
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

        private bool SGPAExists(string id)
        {
            return _context.SGPA.Any(e => e.SGPAID == id);
        }
    }
}
