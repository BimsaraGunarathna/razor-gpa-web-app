﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using razor_gpa_web_app.Data;
using razor_gpa_web_app.Models;

namespace razor_gpa_web_app.Pages.Degrees
{
    public class IndexModel : PageModel
    {
        private readonly razor_gpa_web_app.Data.DBContext _context;

        public IndexModel(razor_gpa_web_app.Data.DBContext context)
        {
            _context = context;
        }

        public IList<Degree> Degree { get;set; }

        public async Task OnGetAsync()
        {
            Degree = await _context.Degree
                .Include(d => d.Department).ToListAsync();
        }
    }
}