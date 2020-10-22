using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using razor_gpa_web_app.Data;
using razor_gpa_web_app.Models;

namespace razor_gpa_web_app.Pages.YGPAs
{
    public class DetailsModel : PageModel
    {
        private readonly razor_gpa_web_app.Data.AppDBContext _context;

        public DetailsModel(razor_gpa_web_app.Data.AppDBContext context)
        {
            _context = context;
        }

        public YGPA YGPA { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            YGPA = await _context.YGPA.FirstOrDefaultAsync(m => m.YGPAID == id);

            if (YGPA == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
