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
    public class DetailsModel : PageModel
    {
        private readonly razor_gpa_web_app.Data.DBContext _context;

        public DetailsModel(razor_gpa_web_app.Data.DBContext context)
        {
            _context = context;
        }

        public GPA GPA { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GPA = await _context.GPA
                .Include(g => g.ApplicationUser)
                .Include(g => g.Semester)
                .Include(g => g.SubjectModule)
                .Include(g => g.Year).FirstOrDefaultAsync(m => m.GPAID == id);

            if (GPA == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
