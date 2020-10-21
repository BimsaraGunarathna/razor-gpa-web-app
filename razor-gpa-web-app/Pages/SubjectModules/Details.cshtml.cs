﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using gpa_system.Models;
using razor_gpa_web_app.Data;

namespace razor_gpa_web_app.Pages.SubjectModules
{
    public class DetailsModel : PageModel
    {
        private readonly razor_gpa_web_app.Data.DBContext _context;

        public DetailsModel(razor_gpa_web_app.Data.DBContext context)
        {
            _context = context;
        }

        public SubjectModule SubjectModule { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SubjectModule = await _context.SubjectModule.FirstOrDefaultAsync(m => m.SubjectModuleID == id);

            if (SubjectModule == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
