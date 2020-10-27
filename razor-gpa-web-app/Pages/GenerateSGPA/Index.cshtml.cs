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

namespace razor_gpa_web_app.Pages.GenerateSGPA
{
    public class IndexModel : PageModel
    {
        private readonly DBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        //
        public string UserId { get; set; }

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


        //public List SGPAList { get; set; }
        //public List<Double> Book { get; set;  }
        public List<SGPAList> SGPAList { get; set; }


        //Semester01
        public Double cumalativeGgpaForSem01 { get; set; }
        public Double cumalativeCreditForSem01 { get; set; }
        public Double spgpaForSem01 { get; set; }

        public async Task OnGetAsync()
        {
            //user id
            //UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            //UserId = _userManager.GetUserId(User);

            //ClaimsPrincipal principal = User as ClaimsPrincipal;
            //string UserID = _signInManager.UserManager.GetUserId(principal);

            var UserId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId

            if (UserId == null)
            {
                RedirectToPage("./Index");
            }

            //var selectedGPAs = _context.GPA.Where(n => n.StudentID == UserId);

            var gpaForSem01 = from m in _context.GPA
                         where m.StudentID == UserId
                         where m.SemesterID == "1"
                         select m;

            var creditFrSem01 = from n in _context.Paper
                                    from s in _context.Grade
                                    where n.SemesterID == "1"
                                    where n.GradeID == s.GradeID
                                    select s;
                                   
            foreach( var q in creditFrSem01)
            {
                cumalativeCreditForSem01 += q.CreditValue;
            }

            foreach( var i in gpaForSem01)
            {
                cumalativeGgpaForSem01 += i.GPAValue;
            }

            spgpaForSem01 = cumalativeGgpaForSem01 / cumalativeCreditForSem01;
            

            /*
            var sortedGpa = null;
            foreach ( var i in gpa )
            {
                sortedGpa.Add( )
                //SGPAList.Add(new SGPAList { Id = i.GPAID, SGPAForSemOne = i.GPAValue });
                //SGPAList.Add(new SGPAList { Id = "jhvbjhbwu", SGPAForSemOne = 12.09787 });
            }

            //SGPAList = await gpa.ToListAsync();
            List rna = await SGPAList.ToListAsync();
            */
            /*
            foreach (var r in Movie)
            {
                SGPAList.Add((r.StudentID).ToString());
            }
            */
        }

    }
}
