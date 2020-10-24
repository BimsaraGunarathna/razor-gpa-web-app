using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using razor_gpa_web_app.Data;
using razor_gpa_web_app.Models;

namespace razor_gpa_web_app.Pages.Degrees
{
    public class DeleteModel : PageModel
    {
        private readonly razor_gpa_web_app.Data.DBContext _context;

        public DeleteModel(razor_gpa_web_app.Data.DBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Degree Degree { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Degree = await _context.Degree
                .AsNoTracking()
                .Include(d => d.Department).
                FirstOrDefaultAsync(m => m.DegreeID == id);

            if (Degree == null)
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

            Degree = await _context.Degree.FindAsync(id);

            if (Degree != null)
            {
                _context.Degree.Remove(Degree);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
