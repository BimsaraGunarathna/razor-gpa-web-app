using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using razor_gpa_web_app.Areas.Identity.Data;
using razor_gpa_web_app.Data;
using razor_gpa_web_app.Models;

namespace razor_gpa_web_app.Pages.GetAllGPAs
{
    public class GetYGPAFGPAs : PageModel
    {
        private readonly DBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        //
        //public IList<FakeSGPA> StudentGPAList { get; set; }

        //known issue: avoided null exception occurred: public IList<FakeSGPA> StudentGPAList { get; set; }
        public IList<FakeSGPA> StudentGPAList = new List<FakeSGPA>();

        public string UserId { get; set; }
        public string userDeptID { get; set; }

        public GetYGPAFGPAs (
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
            //get the user id
            UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            //Get the user
            var AppUser = await _userManager.GetUserAsync(User);

            userDeptID = AppUser.DepartmentID;

            if (UserId == null || userDeptID == null)
            {
                RedirectToPage("./Index");
            }


            var studentListByDept = from n in _context.ApplicationUser
                                    where n.DepartmentID == userDeptID
                                    select n;

            var degreeDuration = (from r in _context.ApplicationUser
                                  from u in _context.Degree
                                  where r.DegreeID == u.DegreeID
                                  select u.NumOfYears).FirstOrDefault();

            //go throught users of the dept
            foreach (var i in studentListByDept)
            {
                FakeSGPA fakesgpa = new FakeSGPA();
                //User
                fakesgpa.FirstName = i.FirstName;
                fakesgpa.LastName = i.LastName;
                fakesgpa.RegNum = i.RegNum;
                //Semester
                fakesgpa.SGPAValueForSemOne = CalculateSGPA(_context: _context, _userId: i.Id, _semesterId: "1");
                fakesgpa.SGPAValueForSemTwo = CalculateSGPA(_context: _context, _userId: i.Id, _semesterId: "2");
                fakesgpa.SGPAValueForSemThree = CalculateSGPA(_context: _context, _userId: i.Id, _semesterId: "3");
                fakesgpa.SGPAValueForSemFour = CalculateSGPA(_context: _context, _userId: i.Id, _semesterId: "4");
                fakesgpa.SGPAValueForSemFive = CalculateSGPA(_context: _context, _userId: i.Id, _semesterId: "5");
                fakesgpa.SGPAValueForSemSix = CalculateSGPA(_context: _context, _userId: i.Id, _semesterId: "6");
                fakesgpa.SGPAValueForSemSeven = CalculateSGPA(_context: _context, _userId: i.Id, _semesterId: "7");
                fakesgpa.SGPAValueForSemEight = CalculateSGPA(_context: _context, _userId: i.Id, _semesterId: "8");
                fakesgpa.SGPAValueForSemNine = CalculateSGPA(_context: _context, _userId: i.Id, _semesterId: "9");
                fakesgpa.SGPAValueForSemTen = CalculateSGPA(_context: _context, _userId: i.Id, _semesterId: "10");

                //Year
                fakesgpa.YGPAValueForYearOne = (double)(fakesgpa.SGPAValueForSemOne + fakesgpa.SGPAValueForSemTwo) / 2;
                fakesgpa.YGPAValueForYearTwo = (double)(fakesgpa.SGPAValueForSemThree + fakesgpa.SGPAValueForSemFour) / 2;
                fakesgpa.YGPAValueForYearThree = (double)(fakesgpa.SGPAValueForSemFive + fakesgpa.SGPAValueForSemSix) / 2;
                fakesgpa.YGPAValueForYearFour = (double)(fakesgpa.SGPAValueForSemSeven + fakesgpa.SGPAValueForSemEight) / 2;
                fakesgpa.YGPAValueForYearFive = (double)(fakesgpa.SGPAValueForSemNine + fakesgpa.SGPAValueForSemTen) / 2;
                
                //FGPA
                if (degreeDuration == 4)
                {
                    fakesgpa.FGPAValue = (double)(fakesgpa.YGPAValueForYearOne + fakesgpa.YGPAValueForYearTwo + fakesgpa.YGPAValueForYearThree + fakesgpa.YGPAValueForYearFour) / 4;
                }
                else
                {
                    fakesgpa.FGPAValue = (double)(fakesgpa.YGPAValueForYearOne + fakesgpa.YGPAValueForYearTwo + fakesgpa.YGPAValueForYearThree + fakesgpa.YGPAValueForYearFour + fakesgpa.YGPAValueForYearFive) / 5;
                }

                StudentGPAList.Add(fakesgpa);
            }

        }

        Double CalculateSGPA(DBContext _context, string _userId, string _semesterId)
        {
            var gpaForSem01 = from m in _context.Paper
                              where m.StudentID == _userId
                              where m.SemesterID == _semesterId
                              select m;

            var creditFrSem01 = from n in _context.Paper
                                from s in _context.Grade
                                where n.SemesterID == _semesterId
                                where n.GradeID == s.GradeID
                                select s;

            Double cumalativeCreditForSem01 = 0.00, cumalativeGgpaForSem01 = 0.00, sgpa = 0.00;
            foreach (var q in creditFrSem01)
            {
                cumalativeCreditForSem01 += q.CreditValue;
            }

            foreach (var i in gpaForSem01)
            {
                cumalativeGgpaForSem01 += i.GPAValue;
            }

            //spgpaForSem01 = cumalativeGgpaForSem01 / cumalativeCreditForSem01;
            return sgpa = Math.Round((cumalativeGgpaForSem01 / cumalativeCreditForSem01), 2);
        }
    }
}
