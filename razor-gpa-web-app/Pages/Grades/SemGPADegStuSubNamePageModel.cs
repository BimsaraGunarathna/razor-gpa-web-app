using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using razor_gpa_web_app.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace razor_gpa_web_app.Pages.Grades
{
    public class SemGPADegStuSubNamePageModel: PageModel
    {

        //SubjectModule1
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

        //Student1
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

        //Semester1
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

        //Degree1
        public SelectList DegreeNameSL { get; set; }

        public void PopulateDegreeDropDownList(DBContext _context,
            object selectedDegree = null)
        {
            var degreeQuery = from d in _context.Degree
                            orderby d.DegreeName // Sort by name.
                            select d;

            DegreeNameSL = new SelectList(degreeQuery.AsNoTracking(),
                        "DegreeID", "DegreeName", selectedDegree);
        }

        //GPA1
        public SelectList GPANameSL { get; set; }

        public void PopulateGPADropDownList(DBContext _context,
            object selectedGPA = null)
        {
            var gPAQuery = from d in _context.GPA
                              orderby d.GPAValue // Sort by name.
                              select d;

            GPANameSL = new SelectList(gPAQuery.AsNoTracking(),
                        "GPAID", "GPAValue", selectedGPA);
        }

    }
}
