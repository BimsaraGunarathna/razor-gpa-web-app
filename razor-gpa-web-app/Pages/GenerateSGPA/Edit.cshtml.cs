﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using razor_gpa_web_app.Areas.Identity.Data;
using razor_gpa_web_app.Data;
using razor_gpa_web_app.Models;

namespace razor_gpa_web_app.Pages.GenerateSGPA
{
    public class EditModel : PageModel
    {
        private readonly razor_gpa_web_app.Data.DBContext _context;

        public EditModel(razor_gpa_web_app.Data.DBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Paper Paper { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Paper = await _context.Paper
                .Include(p => p.ApplicationUser)
                .Include(p => p.Degree)
                .Include(p => p.Grade)
                .Include(p => p.Semester)
                .Include(p => p.SubjectModule).FirstOrDefaultAsync(m => m.PaperID == id);

            if (Paper == null)
            {
                return NotFound();
            }
            ViewData["StudentID"] = new SelectList(_context.Set<ApplicationUser>(), "Id", "RegNum");
            ViewData["DegreeID"] = new SelectList(_context.Degree, "DegreeID", "DegreeName");
            ViewData["GradeID"] = new SelectList(_context.Grade, "GradeID", "GradeName");
            ViewData["SemesterID"] = new SelectList(_context.Set<Semester>(), "SemesterID", "SemesterName");
            ViewData["SubjectModuleID"] = new SelectList(_context.Set<SubjectModule>(), "SubjectModuleID", "SubjectModuleName");
            ViewData["AcademicYearID"] = new SelectList(_context.Set<AcademicYear>(), "AcademicYearID", "StartDate");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Paper).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaperExists(Paper.PaperID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PaperExists(string id)
        {
            return _context.Paper.Any(e => e.PaperID == id);
        }
    }
}