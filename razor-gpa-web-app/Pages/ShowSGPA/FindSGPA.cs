using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using razor_gpa_web_app.Areas.Identity.Data;
using razor_gpa_web_app.Data;
using razor_gpa_web_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace razor_gpa_web_app.Pages.ShowSGPA
{
    public class FindSGPA : PageModel
    {
        

        //List<GPA> gpaForStudent;

        public GPA GPA { get; set; }

        public async void CalculateSGPA(DBContext _context, UserManager<ApplicationUser> _userManager)
        {
            var user = await _userManager.GetUserAsync(User);
            string intakeId = user.IntakeID;
            var userId = _userManager.GetUserId(User);

            //
            //var papers = _context.Paper;
            //var papers = _context.Paper;
            //List<GPA> gpaForStudent;
            var sem = from s in _context.Semester
                       select s;

            var papers = from m in _context.Paper
                         select m;
            if (!string.IsNullOrEmpty(userId))
            {
                papers = papers.Where(p => p.StudentID == userId);
                
            }

            //string academicYear = sem.Where(s => s.SemesterID == "").Select(d => d.AcademicYearID).ToString();

            foreach (Paper r in papers)
            {
                GPA = new GPA
                {
                    GPAID = Guid.NewGuid().ToString(),
                    SemesterID = "kjei3322",
                    SubjectModuleID = "th45hr",
                    StudentID = userId,
                    AcademicYearID = "myud",
                    GPAValue = 1.70
                    /*
                    GPAID = Guid.NewGuid().ToString(),
                    SemesterID = r.SemesterID,
                    SubjectModuleID = r.SubjectModuleID,
                    StudentID = userId,
                    AcademicYearID = sem.Where(s => s.SemesterID == r.SemesterID).Select(d => d.AcademicYearID).ToString(),
                    GPAValue = 1.70
                    */
                };
                _context.GPA.Add(GPA);
                await _context.SaveChangesAsync();
            }
            
            /*
            var subjects = from s in _context.SubjectModule
                           select s;
            foreach(Paper p in papers)
            {
                subjects = subjects.Where( r => r.)
            }

            
            var paperQuery = from d in _context.Paper
                             orderby d.PaperID
                             select d.StudentID == user
                             select d;
            
            var brandItems = await _context.Paper
                .Where(b => b.StudentID == user)
                .OrderBy(b => b.SemesterID)
                .Select(b => new SelectList
                {
                    SemesterID = b.SemesterID,
                    SubjectModulesID = b.SubjectModuleID,
                    GradeID = b.GradeID
                })
                .ToListAsync();

            */
            //var user = await GetCurrentUserAsync();
            //var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)
            /*
            var departmentsQuery = from d in _context.Department
                                   orderby d.DepartmentName // Sort by name.
                                   select d;

            DepartmentNameSL = new SelectList(departmentsQuery.AsNoTracking(),
                        "DepartmentID", "DepartmentName", selectedDepartment);
            */
        }
    }
}
