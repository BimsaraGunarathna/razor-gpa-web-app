using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using razor_gpa_web_app.Data;
using razor_gpa_web_app.Models;

namespace razor_gpa_web_app.Pages.Papers
{
    public class IndexModel : PageModel
    {
        private readonly razor_gpa_web_app.Data.DBContext _context;

        public IndexModel(razor_gpa_web_app.Data.DBContext context)
        {
            _context = context;
        }

        public IList<Paper> Paper { get;set; }

        public async Task OnGetAsync()
        {
            Paper = await _context.Paper
                .Include(p => p.ApplicationUser)
                .Include(p => p.Degree)
                .Include(p => p.GPA)
                .Include(p => p.Grade)
                .Include(p => p.Semester)
                .Include(p => p.SubjectModule).ToListAsync();
        }
    }
}
