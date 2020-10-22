using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using razor_gpa_web_app.Areas.Identity.Data;
using razor_gpa_web_app.Data;
using razor_gpa_web_app.Models;
using razor_gpa_web_app.Utility;

namespace razor_gpa_web_app.Pages.UserModels
{
    [Authorize(Roles = SD.AdminEndUser )]
    public class IndexModel : PageModel
    {
        private readonly razor_gpa_web_app.Data.DBContext _context;

        public IndexModel(razor_gpa_web_app.Data.DBContext context)
        {
            _context = context;
        }

        public IList<ApplicationUser> ApplicationUser { get;set; }

        public async Task OnGetAsync()
        {
            ApplicationUser = await _context.ApplicationUser.ToListAsync();
        }
    }
}
