using System;
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
    public class IndexModel : PageModel
    {
        private readonly razor_gpa_web_app.Data.DBContext _context;

        public IndexModel(razor_gpa_web_app.Data.DBContext context)
        {
            _context = context;
        }

        public IList<SubjectModule> SubjectModule { get;set; }

        public async Task OnGetAsync()
        {
            SubjectModule = await _context.SubjectModule.ToListAsync();
        }
    }
}
