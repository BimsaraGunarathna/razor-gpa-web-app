﻿using System;
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
            //user id
            UserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            
            if (UserId == null)
            {
                RedirectToPage("./Index");
            }

            SemesterOneGPA = CalculateSGPA(_context: _context, _userId: UserId, _semesterId: "1");

            SemesterTwoGPA = CalculateSGPA(_context: _context, _userId: UserId, _semesterId: "2");

            SemesterThreeGPA = CalculateSGPA(_context: _context, _userId: UserId, _semesterId: "3");

            SemesterFourGPA = CalculateSGPA(_context: _context, _userId: UserId, _semesterId: "4");

            SemesterFiveGPA = CalculateSGPA(_context: _context, _userId: UserId, _semesterId: "5");

            SemesterSixGPA = CalculateSGPA(_context: _context, _userId: UserId, _semesterId: "6");

            SemesterSevenGPA = CalculateSGPA(_context: _context, _userId: UserId, _semesterId: "7");

            SemesterEightGPA = CalculateSGPA(_context: _context, _userId: UserId, _semesterId: "8");

            SemesterNineGPA = CalculateSGPA(_context: _context, _userId: UserId, _semesterId: "9");

            SemesterTenGPA = CalculateSGPA(_context: _context, _userId: UserId, _semesterId: "10");

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
