using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using razor_gpa_web_app.Data;
using razor_gpa_web_app.Models;

namespace razor_gpa_web_app.Pages.SGPAs
{
    public class IndexModel : PageModel
    {
        private readonly razor_gpa_web_app.Data.AppDBContext _context;

        public IndexModel(razor_gpa_web_app.Data.AppDBContext context)
        {
            _context = context;
        }

        public IList<SGPA> SGPA { get;set; }

        public async Task OnGetAsync()
        {
            SGPA = await _context.SGPA
                .Include(s => s.Semester)
                .Include(s => s.Year).ToListAsync();
        }
    }
}
