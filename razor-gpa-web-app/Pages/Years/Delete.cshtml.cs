using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using razor_gpa_web_app.Data;
using razor_gpa_web_app.Models;

namespace razor_gpa_web_app.Pages.Years
{
    public class DeleteModel : PageModel
    {
        private readonly razor_gpa_web_app.Data.AppDBContext _context;

        public DeleteModel(razor_gpa_web_app.Data.AppDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Year Year { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Year = await _context.Year.FirstOrDefaultAsync(m => m.YearID == id);

            if (Year == null)
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

            Year = await _context.Year.FindAsync(id);

            if (Year != null)
            {
                _context.Year.Remove(Year);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
