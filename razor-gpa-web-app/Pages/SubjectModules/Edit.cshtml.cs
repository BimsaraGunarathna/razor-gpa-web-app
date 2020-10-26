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

namespace razor_gpa_web_app.Pages.SubjectModules
{
    public class EditModel : PageModel
    {
        private readonly razor_gpa_web_app.Data.DBContext _context;

        public EditModel(razor_gpa_web_app.Data.DBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SubjectModule SubjectModule { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SubjectModule = await _context.SubjectModule
                .Include(s => s.Degree).FirstOrDefaultAsync(m => m.SubjectModuleID == id);

            if (SubjectModule == null)
            {
                return NotFound();
            }
            ViewData["DegreeID"] = new SelectList(_context.Degree, "DegreeID", "DegreeName");
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

            _context.Attach(SubjectModule).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubjectModuleExists(SubjectModule.SubjectModuleID))
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

        private bool SubjectModuleExists(string id)
        {
            return _context.SubjectModule.Any(e => e.SubjectModuleID == id);
        }
    }
}
