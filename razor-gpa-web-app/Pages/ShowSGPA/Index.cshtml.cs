using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using razor_gpa_web_app.Areas.Identity.Data;
using razor_gpa_web_app.Data;
using razor_gpa_web_app.Models;

namespace razor_gpa_web_app.Pages.ShowSGPA
{
    public class IndexModel : PageModel
    {
        private razor_gpa_web_app.Data.DBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public IndexModel(DBContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Paper> Paper { get;set; }

        public async Task OnGet()
        {


            var GPA = new GPA
            {
                GPAID = Guid.NewGuid().ToString(),
                SemesterID = "kjei3322",
                SubjectModuleID = "th45hr",
                StudentID = "af79b10f-e1d3-4090-9949-6d503d29462a",
                AcademicYearID = "myud",
                GPAValue = 1.70
            };
            _context.GPA.Add(GPA);
            await _context.SaveChangesAsync();


            //CalculateSGPA(_context, _userManager);
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
