using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using razor_gpa_web_app.Areas.Identity.Data;
using razor_gpa_web_app.Data;
using razor_gpa_web_app.Models;

namespace razor_gpa_web_app.Pages.SGPAs
{
    public class CreateModel : PageModel
    {
        private readonly razor_gpa_web_app.Data.DBContext _context;

        public CreateModel(razor_gpa_web_app.Data.DBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["SemesterID"] = new SelectList(_context.Semester, "SemesterID", "SemesterID");
        ViewData["StudentID"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "Id");
        ViewData["YearID"] = new SelectList(_context.Set<Year>(), "YearID", "YearID");
            return Page();
        }

        [BindProperty]
        public SGPA SGPA { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.SGPA.Add(SGPA);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
