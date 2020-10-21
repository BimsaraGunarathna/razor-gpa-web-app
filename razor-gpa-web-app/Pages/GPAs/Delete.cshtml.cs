using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using razor_gpa_web_app.Data;
using razor_gpa_web_app.Models;

namespace razor_gpa_web_app.Pages.GPAs
{
    public class DeleteModel : PageModel
    {
        private readonly razor_gpa_web_app.Data.DBContext _context;

        public DeleteModel(razor_gpa_web_app.Data.DBContext context)
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
                .Include(g => g.Semester)
                .Include(g => g.SubjectModule).FirstOrDefaultAsync(m => m.GPAID == id);

            if (GPA == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GPA = await _context.GPA.FindAsync(id);

            if (GPA != null)
            {
                _context.GPA.Remove(GPA);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
