﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using razor_gpa_web_app.Data;
using razor_gpa_web_app.Models;

namespace razor_gpa_web_app.Pages.YGPAs
{
    public class DeleteModel : PageModel
    {
        private readonly razor_gpa_web_app.Data.DBContext _context;

        public DeleteModel(razor_gpa_web_app.Data.DBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public YGPA YGPA { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            YGPA = await _context.YGPA
                .Include(y => y.AcademicYear)
                .Include(y => y.ApplicationUser).FirstOrDefaultAsync(m => m.YGPAID == id);

            if (YGPA == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            YGPA = await _context.YGPA.FindAsync(id);

            if (YGPA != null)
            {
                _context.YGPA.Remove(YGPA);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}