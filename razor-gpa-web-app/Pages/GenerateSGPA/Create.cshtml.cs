using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using razor_gpa_web_app.Areas.Identity.Data;
using razor_gpa_web_app.Data;
using razor_gpa_web_app.Models;

namespace razor_gpa_web_app.Pages.GenerateSGPA
{
    public class CreateModel : PageModel
    {
        private readonly razor_gpa_web_app.Data.DBContext _context;
        public readonly UserManager<ApplicationUser> _userManager;

        public CreateModel(DBContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
        ViewData["StudentID"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "RegNum");
        ViewData["DegreeID"] = new SelectList(_context.Degree, "DegreeID", "DegreeName");
        ViewData["GPAID"] = new SelectList(_context.GPA, "GPAID", "GPAID");
        ViewData["GradeID"] = new SelectList(_context.Grade, "GradeID", "GradeName");
        ViewData["SemesterID"] = new SelectList(_context.Set<Semester>(), "SemesterID", "SemesterName");
        ViewData["SubjectModuleID"] = new SelectList(_context.Set<SubjectModule>(), "SubjectModuleID", "SubjectModuleName");
        ViewData["AcademicYearID"] = new SelectList(_context.Set<AcademicYear>(), "AcademicYearID", "StartDate");
            return Page();
        }

        [BindProperty]
        public Paper Paper { get; set; }

        public GPA GPA { get; set; }


        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //var user = await _userManager.GetUserAsync(User);
            /*
            var selectedGrade = (_context.Grade
                .Where(g => g.GradeID == Paper.GradeID)
            .Select(f => f.CreditValue))
            .Single();

            var selectedSubject = (_context.SubjectModule
                .Where(g => g.SubjectModuleID == Paper.SubjectModuleID)
                .Select(r => r.SubjectModuleCreditUnit))
                .Single();

            //var gradeVal = selectedGrade.Where(g => g.GradeID == Paper.GradeID);

            //double calculatedGPA = (Convert.ToDouble(selectedGrade.CreditValue)) * (Convert.ToDouble(selectedSubject.SubjectModuleCreditUnit));

            */
            Double selectedGrade = (from m in _context.Grade
                                where m.GradeID == Paper.GradeID
                                select m.CreditValue).Single();

            int selectedSubject = (from m in _context.SubjectModule
                                  where m.SubjectModuleID == Paper.SubjectModuleID
                                select m.SubjectModuleCreditUnit).Single();

            Double calculatedGPA = Convert.ToDouble(selectedSubject) * selectedGrade;

            GPA = new GPA
            {
                GPAID = Guid.NewGuid().ToString(),
                SemesterID = Paper.SemesterID,
                SubjectModuleID = Paper.SubjectModuleID,
                StudentID = Paper.StudentID,
                AcademicYearID = Paper.AcademicYearID,
                GPAValue = calculatedGPA
            };


            _context.GPA.Add(GPA);
            _context.Paper.Add(Paper);

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
