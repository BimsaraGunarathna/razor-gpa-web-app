using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using razor_gpa_web_app.Data;
using razor_gpa_web_app.Models;

namespace razor_gpa_web_app.Pages.Grades
{
    public class DetailsModel : PageModel
    {
        private readonly razor_gpa_web_app.Data.DBContext _context;

        public DetailsModel(razor_gpa_web_app.Data.DBContext context)
        {
            _context = context;
        }

        public Grade Grade { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Grade = await _context.Grade
                .Include(g => g.ApplicationUser)
                .Include(g => g.Degree)
                .Include(g => g.GPA)
                .Include(g => g.Semester)
                .Include(g => g.SubjectModule).FirstOrDefaultAsync(m => m.GradeID == id);

            if (Grade == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
