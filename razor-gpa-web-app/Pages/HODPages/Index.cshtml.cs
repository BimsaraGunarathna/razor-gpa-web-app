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

namespace razor_gpa_web_app.Pages.HODPages
{
    public class IndexModel : PageModel
    {
        private readonly DBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        //
        
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

        //
        //public IList<FakeSGPA> StudentGPAList { get; set; }

        //known issue: avoided null exception occurred: public IList<FakeSGPA> StudentGPAList { get; set; }
        public IList<FakeSGPA> StudentGPAList = new List<FakeSGPA>();

        public string UserId { get; set; }
        public string userDeptID { get; set; }

        public IndexModel(
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
            
            //go throught users of the dept
            foreach (var i in studentListByDept)
            {
                var fakesgpa = new FakeSGPA();

                //User
                fakesgpa.FirstName = "jbf";
                fakesgpa.LastName = "rbrwgw";
                fakesgpa.RegNum = "vjhrvbe";

                //Semester
                fakesgpa.SGPAValueForSemOne =  123.09;
                fakesgpa.SGPAValueForSemTwo =  123.09;
                fakesgpa.SGPAValueForSemThree = 123.09;
                fakesgpa.SGPAValueForSemFour = 123.09;
                fakesgpa.SGPAValueForSemFive = 123.09;
                fakesgpa.SGPAValueForSemSix =  123.09;
                fakesgpa.SGPAValueForSemSeven = 123.09;
                fakesgpa.SGPAValueForSemEight = 123.09;
                fakesgpa.SGPAValueForSemNine = 123.09;
                fakesgpa.SGPAValueForSemTen = 123.09;

                //Year
                fakesgpa.SGPAValueForYearOne = (fakesgpa.SGPAValueForSemOne + fakesgpa.SGPAValueForSemTwo) / 2;
                fakesgpa.SGPAValueForYearOne = (fakesgpa.SGPAValueForSemThree + fakesgpa.SGPAValueForSemFour) / 2;
                fakesgpa.SGPAValueForYearOne = (fakesgpa.SGPAValueForSemFive + fakesgpa.SGPAValueForSemSix) / 2;
                fakesgpa.SGPAValueForYearOne = (fakesgpa.SGPAValueForSemSeven + fakesgpa.SGPAValueForSemEight) / 2;
                fakesgpa.SGPAValueForYearOne = (fakesgpa.SGPAValueForSemNine + fakesgpa.SGPAValueForSemTen) / 2;

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
            return sgpa = (cumalativeGgpaForSem01 / cumalativeCreditForSem01);
        }
    }
}

