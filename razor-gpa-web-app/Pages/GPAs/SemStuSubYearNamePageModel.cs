

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using razor_gpa_web_app.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace razor_gpa_web_app.Pages.GPAs
{
    public class SemStuSubYearNamePageModel : PageModel
    {
        //SubjectModule
        public SelectList SubjectModuleNameSL { get; set; }

        public void PopulateSubjectModuleDropDownList(DBContext _context,
            object selectedSubjectModule = null)
        {
            var subjectModuleQuery = from d in _context.SubjectModule
                                     orderby d.SubjectModuleName // Sort by name.
                                     select d;

            SubjectModuleNameSL = new SelectList(subjectModuleQuery.AsNoTracking(),
                        "SubjectModuleID", "SubjectModuleName", selectedSubjectModule);
        }

        //Student
        public SelectList StudentNameSL { get; set; }

        public void PopulateStudentDropDownList(DBContext _context,
            object selectedStudent = null)
        {
            var studentsQuery = from d in _context.ApplicationUser
                                orderby d.RegNum // Sort by name.
                                select d;

            StudentNameSL = new SelectList(studentsQuery.AsNoTracking(),
                        "StudentID", "StudentName", selectedStudent);
        }

        //Semester
        public SelectList SemesterNameSL { get; set; }

        public void PopulateSemesterDropDownList(DBContext _context,
            object selectedSemester = null)
        {
            var semesterQuery = from d in _context.Semester
                                orderby d.SemesterNumber // Sort by name.
                                select d;

            SemesterNameSL = new SelectList(semesterQuery.AsNoTracking(),
                        "SemesterID", "SemesterNumber", selectedSemester);
        }

        //Year
        public SelectList YearNameSL { get; set; }

        public void PopulateYearDropDownList(DBContext _context,
            object selectedYear = null)
        {
            var yearQuery = from d in _context.Year
                                   orderby d.YearNumber // Sort by name.
                                   select d;

            YearNameSL = new SelectList(yearQuery.AsNoTracking(),
                        "YearID", "YearNumber", selectedYear);
        }
    }
}