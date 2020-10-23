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
    public class DetailsModel : PageModel
    {
        private readonly razor_gpa_web_app.Data.AppDBContext _context;

        public DetailsModel(razor_gpa_web_app.Data.AppDBContext context)
        {
            _context = context;
        }

        public Degree Degree { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Degree = await _context.Degree
                .Include(d => d.Department).FirstOrDefaultAsync(m => m.DegreeID == id);

            if (Degree == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
