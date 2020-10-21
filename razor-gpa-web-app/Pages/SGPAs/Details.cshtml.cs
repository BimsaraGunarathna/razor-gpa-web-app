using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using gpa_system.Models;
using razor_gpa_web_app.Data;

namespace razor_gpa_web_app.Pages.SGPAs
{
    public class DetailsModel : PageModel
    {
        private readonly razor_gpa_web_app.Data.DBContext _context;

        public DetailsModel(razor_gpa_web_app.Data.DBContext context)
        {
            _context = context;
        }

        public SGPA SGPA { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SGPA = await _context.SGPA
                .Include(s => s.Semester).FirstOrDefaultAsync(m => m.SGPAID == id);

            if (SGPA == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
