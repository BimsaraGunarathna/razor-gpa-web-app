using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using razor_gpa_web_app.Areas.Identity.Data;
using razor_gpa_web_app.Data;

namespace razor_gpa_web_app.Pages.Users
{
    public class IndexModel : PageModel
    {
        /*
        private readonly DBContext _db;

        public IndexModel(DBContext db)
        {
            _db = db;
        }
        [BindProperty]
        public IList<ApplicationUser> ApplicationUserList { get; set; }
        public async Task<IActionResult> OnGet()
        {
            ApplicationUserList = await _db.ApplicationUser.ToListAsync();
            return Page();
        }
        */
        private readonly razor_gpa_web_app.Data.DBContext _db;

        public IndexModel(razor_gpa_web_app.Data.DBContext db)
        {
            _db = db;
        }

        public IList<ApplicationUser> ApplicationUserList { get; set; }

        public async Task OnGetAsync()
        {
            ApplicationUserList = await _db.ApplicationUser.ToListAsync();
        }
    }
}
