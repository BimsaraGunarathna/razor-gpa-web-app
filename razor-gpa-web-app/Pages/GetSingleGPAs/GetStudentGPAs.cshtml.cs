using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using razor_gpa_web_app.Areas.Identity.Data;
using razor_gpa_web_app.Data;
using razor_gpa_web_app.Models;

namespace razor_gpa_web_app.Pages.GetSingleGPAs
{
    public class GetSingleGPAs : PageModel
    {
        private readonly DBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        //user's id
        public string UserId { get; set; }

        //Years in degree
        public int YearsInDegree { get; set; }


        public Double SemesterOneGPA { get; set; }
        public Double SemesterTwoGPA { get; set; }
        public Double SemesterThreeGPA { get; set; }
        public Double SemesterFourGPA { get; set; }
        public Double SemesterFiveGPA { get; set; }
        public Double SemesterSixGPA { get; set; }
        public Double SemesterSevenGPA { get; set; }
        public Double SemesterEightGPA { get; set; }
        public Double SemesterNineGPA { get; set; }
        public Double SemesterTenGPA { get; set; }

        //Subject Module Lists
        public IList<FakeSubject> StudentPaperGradeForSemesterOneList = new List<FakeSubject>();
        public IList<FakeSubject> StudentPaperGradeForSemesterTwoList = new List<FakeSubject>();
        public IList<FakeSubject> StudentPaperGradeForSemesterThreeList = new List<FakeSubject>();
        public IList<FakeSubject> StudentPaperGradeForSemesterFourList = new List<FakeSubject>();
        public IList<FakeSubject> StudentPaperGradeForSemesterFiveList = new List<FakeSubject>();
        public IList<FakeSubject> StudentPaperGradeForSemesterSixList = new List<FakeSubject>();
        public IList<FakeSubject> StudentPaperGradeForSemesterSevenList = new List<FakeSubject>();
        public IList<FakeSubject> StudentPaperGradeForSemesterEightList = new List<FakeSubject>();
        public IList<FakeSubject> StudentPaperGradeForSemesterNineList = new List<FakeSubject>();
        public IList<FakeSubject> StudentPaperGradeForSemesterTenList = new List<FakeSubject>();

        public GetSingleGPAs(
            DBContext context, 
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager
            )
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        

        public async Task OnGetAsync()
        {
            //user id
            //get the user id
            UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            //Get the user department
            var AppUser = await _userManager.GetUserAsync(User);
            var userDeptID = AppUser.DepartmentID;

            if (UserId == null)
            {
                RedirectToPage("./Index");
            }

            //Get semester 01
            var papersBySemByStudentSem01 = from p in _context.Set<Paper>()
                                            from g in _context.Set<Grade>().Where( g => g.GradeID == p.GradeID)
                                            from s in _context.Set<SubjectModule>().Where( s => s.SubjectModuleID == p.SubjectModuleID)
                                            where p.StudentID == UserId
                                            where p.SemesterID == "1"
                                            select new { s.SubjectModuleName, g.GradeName };

            if (papersBySemByStudentSem01 != null )
            {
                SemesterOneGPA = CalculateSGPA(_context: _context, _userId: UserId, _semesterId: "1");
                
                foreach (var i in papersBySemByStudentSem01)
                {
                    FakeSubject fakeSubject = new FakeSubject();
                    //Semesters
                    fakeSubject.SubjectGrade = i.GradeName;
                    fakeSubject.SubjectName = i.SubjectModuleName;
                    StudentPaperGradeForSemesterOneList.Add(fakeSubject);
                }
            }

            //Get semester 02
            var papersBySemByStudentSem02 = from p in _context.Set<Paper>()
                                            from g in _context.Set<Grade>().Where(g => g.GradeID == p.GradeID)
                                            from s in _context.Set<SubjectModule>().Where(s => s.SubjectModuleID == p.SubjectModuleID)
                                            where p.StudentID == UserId
                                            where p.SemesterID == "2"
                                            select new { s.SubjectModuleName, g.GradeName };

            if (papersBySemByStudentSem02 != null)
            {
                SemesterTwoGPA = CalculateSGPA(_context: _context, _userId: UserId, _semesterId: "2");

                foreach (var i in papersBySemByStudentSem02)
                {
                    FakeSubject fakeSubject = new FakeSubject();
                    //Semesters
                    fakeSubject.SubjectGrade = i.GradeName;
                    fakeSubject.SubjectName = i.SubjectModuleName;
                    StudentPaperGradeForSemesterTwoList.Add(fakeSubject);
                }
            }

            //Get semester 03
            var papersBySemByStudentSem03 = from p in _context.Set<Paper>()
                                            from g in _context.Set<Grade>().Where(g => g.GradeID == p.GradeID)
                                            from s in _context.Set<SubjectModule>().Where(s => s.SubjectModuleID == p.SubjectModuleID)
                                            where p.StudentID == UserId
                                            where p.SemesterID == "3"
                                            select new { s.SubjectModuleName, g.GradeName };

            if (papersBySemByStudentSem03 != null)
            {
                SemesterThreeGPA = CalculateSGPA(_context: _context, _userId: UserId, _semesterId: "3");

                foreach (var i in papersBySemByStudentSem03)
                {
                    FakeSubject fakeSubject = new FakeSubject();
                    //Semesters
                    fakeSubject.SubjectGrade = i.GradeName;
                    fakeSubject.SubjectName = i.SubjectModuleName;
                    StudentPaperGradeForSemesterThreeList.Add(fakeSubject);
                }
            }

            //Get semester 04
            var papersBySemByStudentSem04 = from p in _context.Set<Paper>()
                                            from g in _context.Set<Grade>().Where(g => g.GradeID == p.GradeID)
                                            from s in _context.Set<SubjectModule>().Where(s => s.SubjectModuleID == p.SubjectModuleID)
                                            where p.StudentID == UserId
                                            where p.SemesterID == "4"
                                            select new { s.SubjectModuleName, g.GradeName };

            if (papersBySemByStudentSem04 != null)
            {
                SemesterFourGPA = CalculateSGPA(_context: _context, _userId: UserId, _semesterId: "4");

                foreach (var i in papersBySemByStudentSem04)
                {
                    FakeSubject fakeSubject = new FakeSubject();
                    //Semesters
                    fakeSubject.SubjectGrade = i.GradeName;
                    fakeSubject.SubjectName = i.SubjectModuleName;
                    StudentPaperGradeForSemesterFourList.Add(fakeSubject);
                }
            }

            YearsInDegree = (from d in _context.Degree
                                from u in _context.ApplicationUser
                                where u.Id == UserId
                                where d.DegreeID == u.DegreeID
                                select d.NumOfYears).Single();

            //3 years degree
            if (YearsInDegree == 3 || YearsInDegree ==  4 || YearsInDegree == 5)
            {
                //Get semester 05
                var papersBySemByStudentSem05 = from p in _context.Set<Paper>()
                                                from g in _context.Set<Grade>().Where(g => g.GradeID == p.GradeID)
                                                from s in _context.Set<SubjectModule>().Where(s => s.SubjectModuleID == p.SubjectModuleID)
                                                where p.StudentID == UserId
                                                where p.SemesterID == "5"
                                                select new { s.SubjectModuleName, g.GradeName };

                if (papersBySemByStudentSem05 != null)
                {
                    SemesterFiveGPA = CalculateSGPA(_context: _context, _userId: UserId, _semesterId: "5");

                    foreach (var i in papersBySemByStudentSem05)
                    {
                        FakeSubject fakeSubject = new FakeSubject();
                        //Semesters
                        fakeSubject.SubjectGrade = i.GradeName;
                        fakeSubject.SubjectName = i.SubjectModuleName;
                        StudentPaperGradeForSemesterFiveList.Add(fakeSubject);
                    }
                }

                //Get semester 06
                var papersBySemByStudentSem06 = from p in _context.Set<Paper>()
                                                from g in _context.Set<Grade>().Where(g => g.GradeID == p.GradeID)
                                                from s in _context.Set<SubjectModule>().Where(s => s.SubjectModuleID == p.SubjectModuleID)
                                                where p.StudentID == UserId
                                                where p.SemesterID == "6"
                                                select new { s.SubjectModuleName, g.GradeName };

                if (papersBySemByStudentSem06 != null)
                {
                    SemesterSixGPA = CalculateSGPA(_context: _context, _userId: UserId, _semesterId: "6");

                    foreach (var i in papersBySemByStudentSem06)
                    {
                        FakeSubject fakeSubject = new FakeSubject();
                        //Semesters
                        fakeSubject.SubjectGrade = i.GradeName;
                        fakeSubject.SubjectName = i.SubjectModuleName;
                        StudentPaperGradeForSemesterSixList.Add(fakeSubject);
                    }
                }
            }

            //4 years degree
            if (YearsInDegree == 4 || YearsInDegree == 5)
            {
                //Get semester 07
                var papersBySemByStudentSem07 = from p in _context.Set<Paper>()
                                                from g in _context.Set<Grade>().Where(g => g.GradeID == p.GradeID)
                                                from s in _context.Set<SubjectModule>().Where(s => s.SubjectModuleID == p.SubjectModuleID)
                                                where p.StudentID == UserId
                                                where p.SemesterID == "7"
                                                select new { s.SubjectModuleName, g.GradeName };

                if (papersBySemByStudentSem07 != null)
                {
                    SemesterSevenGPA = CalculateSGPA(_context: _context, _userId: UserId, _semesterId: "7");

                    foreach (var i in papersBySemByStudentSem07)
                    {
                        FakeSubject fakeSubject = new FakeSubject();
                        //Semesters
                        fakeSubject.SubjectGrade = i.GradeName;
                        fakeSubject.SubjectName = i.SubjectModuleName;
                        StudentPaperGradeForSemesterSevenList.Add(fakeSubject);
                    }
                }

                //Get semester 08
                var papersBySemByStudentSem08 = from p in _context.Set<Paper>()
                                                from g in _context.Set<Grade>().Where(g => g.GradeID == p.GradeID)
                                                from s in _context.Set<SubjectModule>().Where(s => s.SubjectModuleID == p.SubjectModuleID)
                                                where p.StudentID == UserId
                                                where p.SemesterID == "8"
                                                select new { s.SubjectModuleName, g.GradeName };

                if (papersBySemByStudentSem08 != null)
                {
                    SemesterEightGPA = CalculateSGPA(_context: _context, _userId: UserId, _semesterId: "8");

                    foreach (var i in papersBySemByStudentSem08)
                    {
                        FakeSubject fakeSubject = new FakeSubject();
                        //Semesters
                        fakeSubject.SubjectGrade = i.GradeName;
                        fakeSubject.SubjectName = i.SubjectModuleName;
                        StudentPaperGradeForSemesterEightList.Add(fakeSubject);
                    }
                }
            }
            
            // 5 years degree
            if (YearsInDegree == 5)
            {
                //Get semester 09
                var papersBySemByStudentSem09 = from p in _context.Set<Paper>()
                                                from g in _context.Set<Grade>().Where(g => g.GradeID == p.GradeID)
                                                from s in _context.Set<SubjectModule>().Where(s => s.SubjectModuleID == p.SubjectModuleID)
                                                where p.StudentID == UserId
                                                where p.SemesterID == "9"
                                                select new { s.SubjectModuleName, g.GradeName };

                if (papersBySemByStudentSem09 != null)
                {
                    SemesterNineGPA = CalculateSGPA(_context: _context, _userId: UserId, _semesterId: "9");

                    foreach (var i in papersBySemByStudentSem09)
                    {
                        FakeSubject fakeSubject = new FakeSubject();
                        //Semesters
                        fakeSubject.SubjectGrade = i.GradeName;
                        fakeSubject.SubjectName = i.SubjectModuleName;
                        StudentPaperGradeForSemesterNineList.Add(fakeSubject);
                    }
                }

                //Get semester 10
                var papersBySemByStudentSem10 = from p in _context.Set<Paper>()
                                                from g in _context.Set<Grade>().Where(g => g.GradeID == p.GradeID)
                                                from s in _context.Set<SubjectModule>().Where(s => s.SubjectModuleID == p.SubjectModuleID)
                                                where p.StudentID == UserId
                                                where p.SemesterID == "10"
                                                select new { s.SubjectModuleName, g.GradeName };

                if (papersBySemByStudentSem10 != null)
                {
                    SemesterTenGPA = CalculateSGPA(_context: _context, _userId: UserId, _semesterId: "10");

                    foreach (var i in papersBySemByStudentSem10)
                    {
                        FakeSubject fakeSubject = new FakeSubject();
                        //Semesters
                        fakeSubject.SubjectGrade = i.GradeName;
                        fakeSubject.SubjectName = i.SubjectModuleName;
                        StudentPaperGradeForSemesterTenList.Add(fakeSubject);
                    }
                }
            }
        }

        Double CalculateSGPA(DBContext _context, string _userId, string _semesterId)
        {
            var gpaForSem01 = from m in _context.Paper
                              where m.StudentID == _userId
                              where m.SemesterID == _semesterId
                              select m;
            //subject module should be returned
            //thre could be a problem.
            var creditFrSem01 = from n in _context.Paper
                                from s in _context.SubjectModule
                                where n.SemesterID == _semesterId
                                where n.SubjectModuleID == s.SubjectModuleID
                                where n.StudentID == _userId
                                select s;

            Double cumalativeCreditForSem01 = 0.00, cumalativeGgpaForSem01 = 0.00, sgpa = 0.00;
            foreach (var q in creditFrSem01)
            {
                cumalativeCreditForSem01 += q.SubjectModuleCreditUnit;
            }

            foreach (var i in gpaForSem01)
            {
                cumalativeGgpaForSem01 += i.GPAValue;
            }

            return sgpa = Math.Round((cumalativeGgpaForSem01 / cumalativeCreditForSem01), 2);

        }
    }
}

